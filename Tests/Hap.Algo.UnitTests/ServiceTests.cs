using Hap.Algo.Data;
using Hap.Algo.Services;
using NUnit.Framework;

namespace Hap.Algo.UnitTests;

internal class ServiceTests
{
    private IWordListFileSource _wordListSource;
    private IWordListService _wordListService;
    private ITrieService _trieService;

    [SetUp]
    public void Setup()
    {
        _wordListSource = new WordListFileSource();
        _wordListService = new WordListService(_wordListSource);
        _trieService = new TrieService(_wordListService);
    }

    [Test]
    public async Task WordListService_GetWordListAsync()
    {
        var results = await _wordListService.GetWordListAsync();
        Assert.That(results.Count > 0);
    }

    [Test]
    public async Task TrieService_BuildTrie()
    {
        var results = await _trieService.BuildTrie();
        Assert.That(results.Children.Count == 26);
    }
}
