using System.Data;
using System.IO;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;

namespace AtCoderCs.Common.Library;

public class Tester : IDisposable
{
    private static readonly string _solutionName = "AtCoderCs.sln";

    private static readonly string _inputFileName = "Input.txt";
    private static readonly string _outputFileName = "Output.txt";

    private StreamReader _outputSampleReader;

    private object _lockObject = new object();
    private bool _disposed = false;

    public Tester(string problemFolder,
                  string number,
                  string problemLevel)
    {
        var directory = new DirectoryInfo(Environment.CurrentDirectory);
        var solutionDirectory = Tester.GetDirectory(directory, _solutionName);

        var sampleFolder = Path.Combine($"{solutionDirectory}", "Sample", $"{problemFolder}", $"{number}{problemLevel}");
        var inputFilePath = $"{sampleFolder}_{_inputFileName}";
        var outputFilePath = $"{sampleFolder}_{_outputFileName}";

        this.Reader = new StreamReader(inputFilePath);
        this.Writer = new StringWriter();

        _outputSampleReader = new StreamReader(outputFilePath);
    }

    public StreamReader Reader { get; }

    public StringWriter Writer { get; }

    public void Dispose()
    {
        this.Dispose(false);
        GC.SuppressFinalize(this);
    }

    public void Dispose(bool disposing)
    {
        lock (_lockObject)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    this.Reader?.Dispose();
                    this.Writer?.Dispose();
                    _outputSampleReader?.Dispose();
                }

                _disposed = true;
            }
        }
    }

    public IDictionary<int, string> Execute(Action method)
    {
        var actualDic = new Dictionary<int, string>();

        while (!this.Reader.EndOfStream)
        {
            var inputNumber = int.Parse(this.Reader.ReadLine());

            method?.Invoke();

            //末尾にある愛業コードをすべて削除
            var outputStr = this.Writer.ToString().TrimEnd('\r', '\n');

            //末尾に改行コードを一つだけ追加
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine(outputStr);

            actualDic.Add(inputNumber, strBuilder.ToString());
            //内容をクリア
            var tmpBuilder = this.Writer.GetStringBuilder();
            tmpBuilder.Clear();

            //空欄行でなかった場合、空欄行まで読み込む
            var extraLine = this.Reader.ReadLine();
            if (!string.IsNullOrWhiteSpace(extraLine))
            {
                while (true)
                {
                    //空欄行を読み込んだら処理を終了する
                    extraLine = this.Reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(extraLine))
                    {
                        break;
                    }
                }
            }
        }

        return actualDic;
    }

    public IDictionary<int, string> ReadOutputSample()
    {
        var expectedDic = new Dictionary<int, string>();
        while (!_outputSampleReader.EndOfStream)
        {
            //サンプル番号
            var sampleNumber = int.Parse(_outputSampleReader.ReadLine());

            var strBuilder = new StringBuilder();
            while (true)
            {
                //空欄行まで読み込む
                var line = _outputSampleReader.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    strBuilder.AppendLine(line);
                }
                else
                {
                    //空欄を読み込んだ場合は、そこまでが1サンプルの出力例

                    //末尾にある改行コードをすべて削除
                    var expectedOutputStr = strBuilder.ToString().TrimEnd('\r', '\n');

                    //末尾に改行コードを一つだけ追加
                    var formatBuilder = new StringBuilder();
                    formatBuilder.AppendLine(expectedOutputStr);

                    expectedDic.Add(sampleNumber, formatBuilder.ToString());
                    break;
                }
            }
        }

        return expectedDic;
    }

    private static string GetDirectory(DirectoryInfo directory, string fileName)
    {
        var path = Path.Combine(directory.FullName, fileName);
        if (File.Exists(path))
        {
            return directory.FullName;
        }

        if (directory.Parent != null)
        {
            return Tester.GetDirectory(directory.Parent, fileName);
        }

        return string.Empty;
    }
}