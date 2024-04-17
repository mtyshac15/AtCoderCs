using System.Data;
using System.IO;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;

namespace AtCoderCs.Common.Library;

public class Tester : IDisposable
{
    private object _lockObject = new object();
    private bool _disposed = false;

    private StringReader _outputSampleReader;

    public Tester(string inputSampleText, string outputSampleText)
    {
        this.Reader = new StringReader(inputSampleText);
        this.Writer = new StringWriter();

        _outputSampleReader = new StringReader(outputSampleText);
    }

    public StringReader Reader { get; }

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

        while (this.Reader.Peek() > -1)
        {
            var inputNumber = int.Parse(this.Reader.ReadLine());

            method?.Invoke();

            actualDic.Add(inputNumber, this.Writer.ToString().Trim());

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
        while (_outputSampleReader.Peek() > -1)
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
                    expectedDic.Add(sampleNumber, strBuilder.ToString().Trim());
                    break;
                }
            }
        }

        return expectedDic;
    }
}