using AtCoderCs.Common.Library;
using AtCoderCs.Contest.ABC108;
using AtCoderCs.Contest.Tests;
using System.Reflection;
using Xunit;

namespace AtCoderCs.Contest.Tests.ABC108;

public class Problem
{
    private static readonly string _contestSection = $"ABC";
    private static readonly string _problemFolder = Path.Combine($"100_199", "100_109");
    private static readonly string _problemNumber = $"108";

    private SampleFiePath _sampleFiePath;

    public Problem()
    {
        _sampleFiePath = new SampleFiePath(_contestSection, _problemFolder, _problemNumber);
    }

#if false
    [Fact]
    public void SolveA()
    {
        var prblemLevel = $"A";

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        var sample = _sampleFiePath.ReadFiles(prblemLevel);
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
        var prblemLevel = $"B";

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        var sample = _sampleFiePath.ReadFiles(prblemLevel);
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
        var prblemLevel = $"C";

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        var sample = _sampleFiePath.ReadFiles(prblemLevel);
        using (var tester = new Tester(sample.InputText, sample.OutputText))
        {
            var problem = new ProblemC(tester.Reader, tester.Writer);
            Action method = problem.Solve;

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(method);
        }

        TestTools.Judge(expectedDic, actualDic);
    }

    [Fact]
    public void SolveD()
    {
        var prblemLevel = $"D";

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        var sample = _sampleFiePath.ReadFiles(prblemLevel);
        using (var tester = new Tester(sample.InputText, sample.OutputText))
        {
            var problem = new ProblemD(tester.Reader, tester.Writer);
            Action method = problem.Solve;

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(method);
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif
}