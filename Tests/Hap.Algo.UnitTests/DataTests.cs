using Hap.Algo.Data;
using NUnit.Framework;

namespace Hap.Algo.UnitTests;

internal class DataTests
{
    private IWordListFileSource _wordListSource;

    const string FILE_NAME = "./words_alpha.txt";

    [SetUp]
    public void Setup()
    {
        _wordListSource = new WordListFileSource();
    }

    [Test]
    public async Task LoadWordsTest()
    {
        var results = await _wordListSource.GetFrozenWordList(FILE_NAME);

        Assert.That(results.Count > 0);
    }
}
