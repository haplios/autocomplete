using Hap.Algo.Data;
using Hap.Algo.Services;
using NUnit.Framework;

namespace Hap.Algo.UnitTests;

internal class ServiceTests
{
    private IWordListFileSource _wordListFileSource;
    private ITrieService _trieService;
    private const string FILE_NAME = "./words_alpha.txt";

    [SetUp]
    public void Setup()
    {
        _wordListFileSource = new WordListFileSource();
        _trieService = new TrieService();
    }

    [Test]
    public void TrieService_BuildTrie()
    {
        //var results = await _trieService.BuildTrie();
        //Assert.That(results.Children.Count == 26);
    }
}
