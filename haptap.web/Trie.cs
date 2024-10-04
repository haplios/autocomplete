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
                node.Children[c] = new TrieNode();

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
        List<string> words,
        List<char> word)
    {
        if (words == null)
            words = new List<string>();

        if (word == null)
            word = new List<char>();

        if (currentNode.IsEndOfWord)
        {
            words.Add(new string(word.ToArray()));
            word = new List<char>();
            return;
        }

        foreach (var node in currentNode.Children)
        {
            word.Add(node.Key);
            ListWords(node.Value, words, word);
        }
    }
}

public class TrieNode
{
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    public bool IsEndOfWord { get; set; }
}
