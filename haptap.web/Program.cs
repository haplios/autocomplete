
using haptap.web;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    Args = args,
    ContentRootPath = "/app/out",
    WebRootPath = "wwwroot",
});

var app = builder.Build();

var words = await File.ReadAllLinesAsync("words_alpha.txt");
var trie = new Trie();

foreach (var word in words)
    trie.Insert(word);

string ProcessSearch(string searchtext)
{
    if (string.IsNullOrWhiteSpace(searchtext))
        return string.Empty;

    var result = new List<string>();
    var node = trie.FindNode(searchtext.ToArray(), null);

    if (node == null)
        return "no results.";

    trie.ListWords(node, searchtext.ToCharArray(), result);
    return string.Join(" ", result.ToArray());
}

app.Map("/search", (string searchtext) =>
{
    return ProcessSearch(searchtext);
});

app.UseHttpsRedirection();
app.UseFileServer();
app.Run();
