
using haptap.web;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var words = await File.ReadAllLinesAsync("words_alpha.txt");
var trie = new Trie();

foreach (var word in words)
    trie.Insert(word);

string ProcessSearch(string searchtext)
{
    var result = new List<string>();
    var node = trie.FindNode(searchtext.ToArray(), null);

    if (node == null)
        return "No results.";

    trie.ListWords(node, result, searchtext.ToList());
    return string.Join(" ", result.ToArray());
}

app.Map("/search", (string searchtext) =>
{
    return ProcessSearch(searchtext);
});

app.UseHttpsRedirection();
app.UseFileServer();
app.Run();
