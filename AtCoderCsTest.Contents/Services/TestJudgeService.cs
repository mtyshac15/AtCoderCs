using Microsoft.Extensions.Logging;
using Xunit;

namespace AtCoderCsTest.Contents.Services;

public class TestJudgeService
{
    private ILogger _logger;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger"></param>
    public TestJudgeService(ILogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// サンプルを読み取り、処理を実行
    /// </summary>
    /// <param name="sample"></param>
    /// <param name="problemType"></param>
    /// <param name="methodName"></param>
    /// <returns></returns>
    public IReadOnlyCollection<TestResult> Solve(SampleSet sample, Type problemType, string methodName)
    {
        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        //引数ありのコンストラクタ
        var constructor = problemType.GetConstructor(new Type[] { typeof(StringReader), typeof(StringWriter) });
        var method = problemType.GetMethod(methodName);

        using (var tester = new Tester(_logger, sample))
        {
            var instance = constructor.Invoke(new object[] { tester.Reader, tester.Writer });

            //MethodInfoからデリゲートを作成する
            var solveMethod = (Action)Delegate.CreateDelegate(typeof(Action), instance, method);

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(solveMethod);
        }

        var testResults = expectedDic.Join(actualDic,
                                           e => e.Key,
                                           a => a.Key,
                                           (e, a) => new TestResult(e.Key, e.Value, a.Value))
                                     .ToList();
        return testResults;
    }

    /// <summary>
    /// 判定
    /// </summary>
    /// <param name="testResults"></param>
    /// <param name="epsilon"></param>
    public void Judge(IReadOnlyCollection<TestResult> testResults, double epsilon = 0)
    {
        var results = new List<string>();
        var errors = new List<TestResult>();

        if (epsilon > 0)
        {
            foreach (var testResult in testResults)
            {
                //誤差あり
                var detailErros = testResult.CalcDetailErrors(epsilon);
                errors.AddRange(detailErros);
            }
        }
        else
        {
            foreach (var result in testResults)
            {
                if (result.Expected != result.Actual)
                {
                    errors.Add(new TestResult(result.Number, result.Expected, result.Actual));
                }
            }
        }

        if (!errors.Any())
        {
            _logger.LogInformation($"AC");
        }
        else
        {
            _logger.LogInformation($"WA");

            foreach (var result in errors)
            {
                _logger.LogInformation($"No. {result.Number}: ");
                _logger.LogInformation($"Expected: {Environment.NewLine}{result.Expected}");
                _logger.LogInformation($"Actual: {Environment.NewLine}{result.Actual}");
                _logger.LogInformation($"");
            }
        }

        Assert.Empty(errors);
    }
}
