using System.Collections.Frozen;

namespace Hap.Algo.Data;

public interface IWordListFileSource
{
    Task<string[]> GetWords();
    Task<string[]> GetWords(
        string fileName);

    Task<FrozenSet<string>> GetFrozenWordList();
    Task<FrozenSet<string>> GetFrozenWordList(
        string fileName);
}

public class WordListFileSource : IWordListFileSource
{
    const string FILE_NAME = "./words_alpha.txt";

    public async Task<string[]> GetWords()
    {
        return await File.ReadAllLinesAsync(FILE_NAME);
    }

    public async Task<string[]> GetWords(
        string fileName = FILE_NAME)
    {
        return await File.ReadAllLinesAsync(fileName);
    }

    public async Task<FrozenSet<string>> GetFrozenWordList()
    {
        var words = await File.ReadAllLinesAsync(FILE_NAME);
        return words.ToFrozenSet();
    }

    public async Task<FrozenSet<string>> GetFrozenWordList(
        string fileName = FILE_NAME)
    {
        var words = await File.ReadAllLinesAsync(fileName);
        return words.ToFrozenSet();
    }
}

