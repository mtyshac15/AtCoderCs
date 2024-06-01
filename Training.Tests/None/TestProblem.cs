using AtCoderCs.Common.Library;
using AtCoderCs.Training.Sample;
using System.Reflection;
using Xunit;

namespace AtCoderCs.Training.Tests;

public class TestProblem
{
    private static readonly string _contestSection = $"None";

    private SampleFiePath _sampleFiePath;

    public TestProblem()
    {
        _sampleFiePath = new SampleFiePath(_contestSection, string.Empty, string.Empty);
    }

#if true
    [Fact]
    public void Solve()
    {
        var problemLevel = $"Problem";

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        var sample = _sampleFiePath.ReadFiles(problemLevel);
        using (var tester = new Tester(sample.InputText, sample.OutputText))
        {
            var problem = new Problem(tester.Reader, tester.Writer);
            Action method = problem.Solve;

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(method);
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif
}