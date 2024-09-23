using Hap.Algo.Data;
using NUnit.Framework;

namespace Hap.Algo.UnitTests;

internal class DataTests
{
    private IWordListFileSource _wordListFileSource;
    const string FILE_NAME = "./words_alpha.txt";

    [SetUp]
    public void Setup()
    {
        _wordListFileSource = new WordListFileSource();
    }

    [Test]
    public async Task WordListFileSource_GetWordsFrozenSet()
    {
        var results = await _wordListFileSource.GetWordsFrozenSet(FILE_NAME);
        Assert.That(results.Count > 0);
    }
}
