using System.Text;
using Xunit;

namespace AtcoderCs.Training.Tests;

public static class TestTools
{
    public static void Judge(string sampleFolder, string number, string problemLevel, Action method, double epsilon = 0)
    {
        var testList = AtCoderCs.Common.Library.TestTools.TestInOut(sampleFolder, number, problemLevel, method);

        if (epsilon > 0)
        {
            foreach (var testCase in testList)
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
            foreach (var testCase in testList)
            {
                Assert.Equal(testCase.Expected, testCase.Actual);
            }
        }
    }
}