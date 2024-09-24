using Hap.Algo.Data;

const string FILE_NAME = "./words_alpha.txt";
const string OUTPUT = "c:\\tmp\\WORDS.cs";

var wordListFileSource = new WordListFileSource();

var words = await wordListFileSource.GetWords(FILE_NAME);

const string namesp = "namespace Hap.Algo.Data;";
const string classStart = "public static class Constants {";

const string start = "public static readonly string[] WORDS = {";
const string end = "};";

const string classEnd = "}";


using(var stream = new StreamWriter(OUTPUT))
{
    await stream.WriteLineAsync(namesp);
    await stream.WriteLineAsync();
    await stream.WriteLineAsync(classStart);
    await stream.WriteLineAsync();
    await stream.WriteAsync(start);

    var length = start.Length;
    var line = new List<string>();
    foreach(var word in words)
    {
        var quoted = $"\"{word}\"";
        length += quoted.Length;
        line.Add(quoted);

        if(length >= 80)
        {
            await stream.WriteLineAsync(string.Join(",", line) + ',');
            line = [];
            length = 0;
        }
    }

    if(line.Count() > 0)
        await stream.WriteAsync(string.Join(",", line));

    await stream.WriteAsync(end);

    await stream.WriteLineAsync();
    await stream.WriteLineAsync(classEnd);
}

