using BenchmarkDotNet.Attributes;
using Hap.Algo.Data;
using Hap.Algo.Services;
using System.Collections.Frozen;

namespace Hap.Algo.Benchmarks;

[MemoryDiagnoser]
public class TrieLoading
{
    private readonly IWordListFileSource _wordList;
    private readonly ITrieService _trieService;
    private const string FILE_NAME = "./words_alpha.txt";

    private FrozenSet<string>? _frozenWords;
    private string[]? _words;

    public TrieLoading()
    {
        _wordList = new WordListFileSource();
        _trieService = new TrieService();
    }

    [GlobalSetup]
    public async Task Setup()
    {
        //_frozenWords = await _wordList.GetWordsFrozenSet(FILE_NAME);
        _words = await _wordList.GetWords(FILE_NAME);
    }

    [Benchmark]
    public void BenchmarkBuildTrie()
    {
        var trie = _trieService.BuildTrie(_words!);
    }
}
