using Hap.Algo.Data;
using Hap.Algo.Services;
using NUnit.Framework;

namespace Hap.Algo.UnitTests;

internal class ServiceTests
{
    private IWordListFileSource _wordListFileSource;
    private ITrieService _trieService;
    private const string FILE_NAME = "./words_alpha.txt";
    private string[] _words;

    [SetUp]
    public async Task Setup()
    {
        _wordListFileSource = new WordListFileSource();
        _trieService = new TrieService();
        _words = await _wordListFileSource.GetWords(FILE_NAME);
    }

    [Test]
    public void TrieService_BuildTrie()
    {
        var results = _trieService.BuildTrie(_words);
        Assert.That(results.Root().Children.Count == 26);
    }

    [Test]
    public void TrieService_SearchTrie()
    {
        var results = _trieService.BuildTrie(_words);

        var result = results.FindNode("agent".ToCharArray(), null);

        Assert.That(result?.IsEndOfWord == true);
    }
}
