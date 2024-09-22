using System.Collections.Frozen;

namespace Data
{
    public interface IWordListFileSource
    {
        Task<string[]> GetWords(string fileName);
        Task<FrozenSet<string>> GetFrozenWordList(string fileName);
    }

    public class WordListFileSource : IWordListFileSource
    {
        public async Task<string[]> GetWords(string fileName)
        {
            return await File.ReadAllLinesAsync(fileName);
        }

        public async Task<FrozenSet<string>> GetFrozenWordList(string fileName)
        {
            var words = await File.ReadAllLinesAsync(fileName);
            return words.ToFrozenSet();
        }
    }
}
