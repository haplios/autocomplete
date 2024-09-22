using BenchmarkDotNet.Attributes;
using Hap.Algo.Data;
using Hap.Algo.Services;

namespace Hap.Algo.Benchmarks;

[SimpleJob]
public class TrieLoading
{
    private readonly IWordListFileSource _wordList;
    private readonly IWordListService _wordListService;
    private readonly ITrieService _trieService;

    public TrieLoading()
    {
        _wordList = new WordListFileSource();
        _wordListService = new WordListService(_wordList);
        _trieService = new TrieService(_wordListService);
    }

    [Benchmark]
    public async Task LoadData()
    {
        var trie = await _trieService.BuildTrie();
    }
}
