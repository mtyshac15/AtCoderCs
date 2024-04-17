using System.Text;
using Xunit;

namespace AtCoderCs.Contest.Tests;

public static class TestTools
{
    public static void Judge(IDictionary<int, string> expectedDic, IDictionary<int, string> actualDic, double epsilon = 0)
    {
        var testCases = expectedDic.Join(actualDic,
                                         e => e.Key,
                                         a => a.Key,
                                         (e, a) => new
                                         {
                                             Expected = e.Value,
                                             Actual = a.Value
                                         })
                             .Select(x => (x.Expected, x.Actual))
                             .ToList();

        if (epsilon > 0)
        {
            foreach (var testCase in testCases)
            {
                //åÎç∑Ç†ÇË
                var actuaValues = testCase.Actual.Split();
                var expectedValues = testCase.Expected.Split();

                foreach (var item in actuaValues.Zip(expectedValues))
                {
                    double actualValue;
                    double expectedValue;

                    double.TryParse(item.First, out actualValue);
                    double.TryParse(item.Second, out expectedValue);

                    var sub = Math.Abs(actualValue - expectedValue);
                    Assert.True(sub < epsilon);
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