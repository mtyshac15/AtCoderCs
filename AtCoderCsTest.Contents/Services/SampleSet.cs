namespace AtCoderCsTest.Contents.Services;

public class SampleSet
{
    private enum Mode
    {
        None,
        Start,
        Number,
        Sample,
        Empty,
        End,
    }

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
            var _mode = Mode.Start;

            // 入力
            var inputTestCase = new List<string>();
            while (_mode != Mode.End)
            {
                var line = synchronized.ReadLine() ?? string.Empty;

                if (_mode == Mode.Start)
                {
                    if (line != _inputSection)
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        _mode = Mode.Number;
                    }
                }
                else if (_mode == Mode.Number)
                {
                    if (line == _outputSection)
                    {
                        _mode = Mode.End;
                    }
                    else if (int.TryParse(line, out int number))
                    {
                        inputTestCase.Add($"{number}");
                        _mode = Mode.Sample;
                    }
                    else
                    {
                        //throw new FormatException();
                    }
                }
                else if (_mode == Mode.Sample)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (inputTestCase.Count == 1)
                        {
                            // 固定のサンプルを入力
                            inputTestCase.Add($"0");
                            inputTestCase.Add($"0");
                            inputTestCase.Add($"0");
                        }

                        inputTestCase.Add(line);
                        input.AddRange(inputTestCase);
                        inputTestCase.Clear();
                        _mode = Mode.Number;
                    }
                    else
                    {
                        inputTestCase.Add(line);
                    }
                }
            }

            _mode = Mode.Number;

            var outputTestCase = new List<string>();

            // 出力
            while (_mode != Mode.End)
            {
                var line = synchronized.ReadLine() ?? string.Empty;

                if (_mode == Mode.Number)
                {
                    if (line is null
                        || string.IsNullOrWhiteSpace(line))
                    {
                        _mode = Mode.End;
                    }
                    else if (int.TryParse(line, out int number))
                    {
                        outputTestCase.Add($"{number}");
                        _mode = Mode.Sample;
                    }
                    else
                    {
                        //throw new FormatException();
                    }
                }
                else if (_mode == Mode.Sample)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (outputTestCase.Count == 1)
                        {
                            // 固定のサンプルを入力
                            outputTestCase.Add($"");
                        }

                        outputTestCase.Add(line);
                        output.AddRange(outputTestCase);
                        outputTestCase.Clear();
                        _mode = Mode.Number;
                    }
                    else
                    {
                        outputTestCase.Add(line);
                    }
                }
            }
        }

        var inputReader = new StringReader(string.Join(Environment.NewLine, input));
        var outputReader = new StringReader(string.Join(Environment.NewLine, output));

        return new SampleSet(inputReader, outputReader);
    }
}
