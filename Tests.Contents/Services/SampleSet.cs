namespace Tests.Contents.Services;

public class SampleSet
{
    private static readonly string _baseFileName = "Sample";
    private static readonly string _inputSection = "Input";
    private static readonly string _outputSection = "Output";

    private SampleSet(StringReader inputReader, StringReader outputReader)
    {
        this.InputReader = inputReader;
        this.OutputReader = outputReader;
    }

    public StringReader InputReader { get; }

    public StringReader OutputReader { get; }

    public static SampleSet LoadSample(FileInfo sampleFile)
    {
        var input = new List<string>();
        var output = new List<string>();

        using (var reader = new StreamReader(sampleFile.FullName))
        using (var synchronized = StreamReader.Synchronized(reader))
        {
            if (synchronized.ReadLine() != _inputSection)
            {
                throw new FormatException();
            }

            // 入力
            while (true)
            {
                var line = synchronized.ReadLine() ?? string.Empty;
                if (line == _outputSection)
                {
                    break;
                }
                else
                {
                    input.Add(line);
                }
            }

            // 出力
            while (true)
            {
                var line = synchronized.ReadLine();
                if (line is null)
                {
                    break;
                }
                else
                {
                    output.Add(line);
                }
            }
        }

        var inputReader = new StringReader(string.Join(Environment.NewLine, input));
        var outputReader = new StringReader(string.Join(Environment.NewLine, output));

        return new SampleSet(inputReader, outputReader);
    }
}
