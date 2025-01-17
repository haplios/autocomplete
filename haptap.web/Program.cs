
using haptap.web;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
var app = builder.Build();

var words = await File.ReadAllLinesAsync("wwwroot/words_alpha.txt");
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

app.UseFileServer();
app.Run();
