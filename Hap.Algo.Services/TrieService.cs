using Hap.Algo.Common;

namespace Hap.Algo.Services;

public interface ITrieService
{
    Trie BuildTrie(string[] words);
}

public class TrieService : ITrieService
{
    public Trie BuildTrie(string[] words)
    {
        var result = new Trie();

        foreach (var word in words)
        {
            result.Insert(word);
        }

        return result;
    }
}
