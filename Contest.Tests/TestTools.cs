using AtCoderCs.Common.Library;
using Contest.Tests.Services;
using Microsoft.Extensions.Logging;
using System.Text;
using Xunit;

namespace AtCoderCs.Contest.Tests;

public static class TestTools
{
    public static IReadOnlyCollection<TestResult> Solve(SampleSet sample, Type problemType, string methodName)
    {
        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        //引数ありのコンストラクタ
        var constructor = problemType.GetConstructor(new Type[] { typeof(StringReader), typeof(StringWriter) });
        var method = problemType.GetMethod(methodName);

        using (var tester = new Common.Library.Tester(sample))
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

    public static void Judge(ILogger logger, IReadOnlyCollection<TestResult> testResults, double epsilon = 0)
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
            logger.LogInformation($"AC");
        }
        else
        {
            logger.LogInformation($"WA");

            foreach (var result in errors)
            {
                logger.LogInformation($"No. {result.Number}: ");
                logger.LogInformation($"Expected: {result.Expected}");
                logger.LogInformation($"Actual: {result.Actual}");
            }
        }

        Assert.Empty(errors);
    }
}