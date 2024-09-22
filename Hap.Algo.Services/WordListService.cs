using Hap.Algo.Data;
using System.Collections.Frozen;

namespace Hap.Algo.Services;

public interface IWordListService
{
    Task<FrozenSet<string>> GetWordListAsync();
    Task<FrozenSet<string>> GetWordListAsync(string fileName);
}

public class WordListService : IWordListService
{
    private FrozenSet<string>? _words;
    private readonly IWordListFileSource _wordListSource;

    public WordListService(
        IWordListFileSource wordListSource)
    {
        _wordListSource = wordListSource;
    }

    private async Task LoadWords()
    {
        if (_words != null)
            return;

        _words = await _wordListSource.GetFrozenWordList();
    }

    private async Task LoadWords(
        string fileName)
    {
        if (_words != null)
            return;

        _words = await _wordListSource.GetFrozenWordList(fileName);
    }

    public async Task<FrozenSet<string>> GetWordListAsync()
    {
        await LoadWords();
        return Words;
    }

    public async Task<FrozenSet<string>> GetWordListAsync(
        string fileName)
    {
        await LoadWords(fileName);
        return Words;
    }

    private FrozenSet<string> Words
    {
        get
        {
            if (_words != null)
                return _words;

            throw new ApplicationException("Unable to load the words from the data source.");
        }
    }
}
