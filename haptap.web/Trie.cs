namespace haptap.web;

public class Trie
{
    private readonly TrieNode _root;

    public Trie()
    {
        _root = new TrieNode();
    }

    public TrieNode Root() => _root;

    public void Insert(
        string word)
    {
        var node = _root;
        foreach (var c in word)
        {
            if (!node.Children.ContainsKey(c))
                node.Children[c] = new TrieNode() { Key = c };

            node = node.Children[c];
        }
        node.IsEndOfWord = true;
    }

    public TrieNode? FindNode(
        char[] prefix,
        TrieNode? currentNode)
    {
        if (currentNode == null)
            currentNode = _root;

        if (prefix.Length == 0)
            return currentNode;

        var key = prefix[0];

        if (currentNode.Children.ContainsKey(key))
            return FindNode(prefix[1..], currentNode.Children[key]);
        else
            return null;
    }

    public void ListWords(
        TrieNode currentNode,
        char[] word,
        List<string> words)
    {
        if (currentNode.IsEndOfWord)
            words.Add(new string(word));

        foreach (var node in currentNode.Children)
        {
            char[] next = new char[word.Length + 1];
            word.CopyTo(next, 0);
            next[next.Length - 1] = node.Key;
            ListWords(node.Value, next, words);
        }
    }
}

public class TrieNode
{
    public char Key { get; set; }
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    public bool IsEndOfWord { get; set; }
}
