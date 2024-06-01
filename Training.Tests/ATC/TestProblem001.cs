using AtCoderCs.Common.Library;
using AtCoderCs.Training.ATC001;
using AtCoderCs.Training.Tests;
using Xunit;

namespace AtCoderCs.Traing.Tests.ATC001;

public class TestProblem
{
    private static readonly string _contestSection = $"ATC";
    private static readonly string _problemFolder = string.Empty;
    private static readonly string _problemNumber = $"001";

    private SampleFiePath _sampleFiePath;

    public TestProblem()
    {
        _sampleFiePath = new SampleFiePath(_contestSection, _problemFolder, _problemNumber);
    }

#if false
    [Fact]
    public void SolveA()
    {
        var problemLevel = $"A";

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        var sample = _sampleFiePath.ReadFiles(problemLevel);
        using (var tester = new Tester(sample.InputText, sample.OutputText))
        {
            var problem = new ProblemA(tester.Reader, tester.Writer);
            Action method = problem.Solve;

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(method);
        }

        TestTools.Judge(expectedDic, actualDic);
    }

    [Fact]
    public void SolveB()
    {
        var problemLevel = $"B";

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        var sample = _sampleFiePath.ReadFiles(problemLevel);
        using (var tester = new Tester(sample.InputText, sample.OutputText))
        {
            var problem = new ProblemB(tester.Reader, tester.Writer);
            Action method = problem.Solve;

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(method);
        }

        TestTools.Judge(expectedDic, actualDic);
    }

    [Fact]
    public void SolveC()
    {
        var problemLevel = $"C";

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        var sample = _sampleFiePath.ReadFiles(problemLevel);
        using (var tester = new Tester(sample.InputText, sample.OutputText))
        {
            var problem = new ProblemB(tester.Reader, tester.Writer);
            Action method = problem.Solve;

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(method);
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif
}