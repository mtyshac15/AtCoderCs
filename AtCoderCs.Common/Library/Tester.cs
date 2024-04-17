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

            //���e���N���A
            var tmpBuilder = this.Writer.GetStringBuilder();
            tmpBuilder.Clear();

            //�󗓍s�łȂ������ꍇ�A�󗓍s�܂œǂݍ���
            var extraLine = this.Reader.ReadLine();
            if (!string.IsNullOrWhiteSpace(extraLine))
            {
                while (true)
                {
                    //�󗓍s��ǂݍ��񂾂珈�����I������
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
            //�T���v���ԍ�
            var sampleNumber = int.Parse(_outputSampleReader.ReadLine());

            var strBuilder = new StringBuilder();
            while (true)
            {
                //�󗓍s�܂œǂݍ���
                var line = _outputSampleReader.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    strBuilder.AppendLine(line);
                }
                else
                {
                    //�󗓂�ǂݍ��񂾏ꍇ�́A�����܂ł�1�T���v���̏o�͗�
                    expectedDic.Add(sampleNumber, strBuilder.ToString().Trim());
                    break;
                }
            }
        }

        return expectedDic;
    }
}