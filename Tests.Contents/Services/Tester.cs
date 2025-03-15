using Microsoft.Extensions.Logging;
using System.Text;

namespace Tests.Contents.Services;

public class Tester : IDisposable
{
    private object _lockObject = new object();
    private bool _disposed = false;

    private ILogger _logger;
    private StringReader _outputSampleReader;

    public Tester(ILogger logger, SampleSet sample)
    {
        _logger = logger;

        this.Reader = sample.InputReader;
        this.Writer = new StringWriter();

        _outputSampleReader = sample.OutputReader;
    }

    public StringReader Reader { get; }

    public StringWriter Writer { get; }

    public IDictionary<int, string> ReadOutputSample()
    {
        var expectedDic = new Dictionary<int, string>();
        while (_outputSampleReader.Peek() > -1)
        {
            //�T���v���ԍ�
            var sampleNumber = int.Parse(_outputSampleReader.ReadLine()!);

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

    public IDictionary<int, string> Execute(Action method)
    {
        var actualDic = new Dictionary<int, string>();

        while (this.Reader.Peek() > -1)
        {
            int.TryParse(this.Reader.ReadLine(), out int testCase);

            var secondTime = Timer(method);
            _logger.LogInformation($"�e�X�g�P�[�X{testCase}, ��������: {secondTime} ms");

            actualDic.Add(testCase, this.Writer.ToString().Trim());

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

    public static int Timer(Action method)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();

        method?.Invoke();

        sw.Stop();
        return (int)(sw.Elapsed.TotalMilliseconds);
    }

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
}