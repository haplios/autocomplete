using BenchmarkDotNet.Attributes;
using Hap.Algo.Data;

namespace Hap.Algo.Benchmarks;

[SimpleJob]
public class FileLoading
{
    private readonly IWordListFileSource _wordList = new WordListFileSource();
    const string FILE_NAME = "./words_alpha.txt";

    [Benchmark]
    public async Task LoadData()
    {
        var results = await _wordList.GetFrozenWordList(FILE_NAME);
    }
}
