using System.Collections.Frozen;

namespace Hap.Algo.Data;

public interface IWordListFileSource
{
    Task<string[]> GetWords(
        string fileName);

    Task<FrozenSet<string>> GetWordsFrozenSet(
        string fileName);
}

public class WordListFileSource : IWordListFileSource
{
    public async Task<string[]> GetWords(
        string fileName)
    {
        return await File.ReadAllLinesAsync(fileName);
    }

    public async Task<FrozenSet<string>> GetWordsFrozenSet(
        string fileName)
    {
        var words = await File.ReadAllLinesAsync(fileName);
        return words.ToFrozenSet();
    }
}

