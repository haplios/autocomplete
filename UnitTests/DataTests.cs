using Data;
using NUnit.Framework;
using Services;

namespace UnitTests
{

    public class DataTests
    {
        private IWordListFileSource _wordListSource;
        private IWordListService _wordListService;

        const string FILE_NAME = "./words_alpha.txt";

        [SetUp]
        public void Setup()
        {
            _wordListSource = new WordListFileSource();
            _wordListService = new WordListService(_wordListSource);
        }

        [Test]
        public async Task LoadWordsTest()
        {
            var results = await _wordListSource.GetFrozenWordList(FILE_NAME);

            Assert.That(results.Count > 0);
        }

        [Test]
        public async Task WordListServiceTest()
        {
            var results = await _wordListService.GetWordListAsync(FILE_NAME);

            Assert.That(results.Count > 0);
        }

    }
}
