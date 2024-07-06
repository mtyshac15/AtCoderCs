using AtCoderCs.Common.Library;
using System.Text;
using Xunit;

namespace AtCoderCs.Contest.Tests;

public static class TestTools
{
    public static void Solve(SampleDto sample, Type problemType, string methodName, double epsilon = 0)
    {
        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        //引数ありのコンストラクタ
        var constructor = problemType.GetConstructor(new Type[] { typeof(StringReader), typeof(StringWriter) });
        var method = problemType.GetMethod(methodName);

        using (var tester = new Common.Library.Tester(sample.Input, sample.Output))
        {
            var instance = constructor.Invoke(new object[] { tester.Reader, tester.Writer });

            //MethodInfoからデリゲートを作成する
            var solveMethod = (Action)Delegate.CreateDelegate(typeof(Action), instance, method);

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(solveMethod);
        }

        TestTools.Judge(expectedDic, actualDic, epsilon);
    }

    public static void Judge(IDictionary<int, string> expectedDic, IDictionary<int, string> actualDic, double epsilon = 0)
    {
        var testCases = expectedDic.Join(actualDic,
                                         e => e.Key,
                                         a => a.Key,
                                         (e, a) => new
                                         {
                                             Index = e.Key,
                                             Expected = e.Value,
                                             Actual = a.Value
                                         })
                             .Select(x => (x.Expected, x.Actual))
                             .ToList();

        if (epsilon > 0)
        {
            foreach (var testCase in testCases)
            {
                //誤差あり
                var actuaValues = testCase.Actual.Split();
                var expectedValues = testCase.Expected.Split();

                foreach (var item in actuaValues.Zip(expectedValues))
                {
                    double actualValue;
                    double expectedValue;

                    double.TryParse(item.First, out actualValue);
                    double.TryParse(item.Second, out expectedValue);

                    var sub = Math.Abs(actualValue - expectedValue);
                    if (sub < epsilon)
                    {
                        Assert.True(sub < epsilon);
                    }
                    else
                    {
                        Assert.Equal(expectedValue, actualValue);
                    }
                }
            }
        }
        else
        {
            foreach (var testCase in testCases)
            {
                Assert.Equal(testCase.Expected, testCase.Actual);
            }
        }
    }
}