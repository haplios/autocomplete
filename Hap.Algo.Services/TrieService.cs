using Hap.Algo.Common;

namespace Hap.Algo.Services;

public interface ITrieService
{
    Task<TrieNode> BuildTrie();
}

public class TrieService : ITrieService
{
    private readonly IWordListService _wordListService;

    public TrieService(IWordListService wordListService)
    {
        _wordListService = wordListService;
    }

    public async Task<TrieNode> BuildTrie()
    {
        var result = new TrieNode();
        var words = await _wordListService.GetWordListAsync();

        foreach (var word in words)
        {
            var chars = word.ToArray();

            BuildTrieNode(chars, result);
        }

        return result;
    }

    private void BuildTrieNode(
        char[] letters,
        TrieNode root)
    {
        if (letters.Length == 0)
        {
            root.Children.Add('*', null);
            return;
        }

        var letter = letters[0];

        if (!root.Children.ContainsKey(letter))
            root.Children.Add(letter, new TrieNode());

        var node = root.Children[letter];

        if (node != null)
            BuildTrieNode(letters[1..], node);
    }
}
