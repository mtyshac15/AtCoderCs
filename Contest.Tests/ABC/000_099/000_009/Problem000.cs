using AtCoderCs.Common.Library;
using AtCoderCs.Contest.ABC000;
using AtCoderCs.Contest.Tests;
using System.Reflection;
using Xunit;
//[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace AtCoderCs.Contest.Tests.ABC000;

public class Problem
{
    private static readonly string _contestSection = $"ABC";
    private static readonly string _problemFolder = Path.Combine($"000_099", "000_009");
    private static readonly string _problemNumber = $"000";

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

        using (var tester = new Tester(_sampleFilePath, _problemNumber, prblemLevel))
        {
            var problem = new ProblemA(tester.Reader, tester.Writer);
            Action method = problem.Solve;

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(method);
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif

#if false
    [Fact]
    public void SolveB()
    {
        var prblemLevel = $"B";

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        using (var tester = new Tester(_sampleFilePath, _problemNumber, prblemLevel))
        {
            var problem = new ProblemB(tester.Reader, tester.Writer);
            Action method = problem.Solve;

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(method);
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif

#if false
    [Fact]
    public void SolveC()
    {
        var prblemLevel = $"C";

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        using (var tester = new Tester(_sampleFilePath, _problemNumber, prblemLevel))
        {
            var problem = new ProblemC(tester.Reader, tester.Writer);
            Action method = problem.Solve;

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(method);
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif

#if false
    [Fact]
    public void SolveD()
    {
        var prblemLevel = $"D";

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        using (var tester = new Tester(_sampleFilePath, _problemNumber, prblemLevel))
        {
            var problem = new ProblemD(tester.Reader, tester.Writer);
            Action method = problem.Solve;

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(method);
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif

#if false
    [Fact]
    public void SolveE()
    {
        var prblemLevel = $"E";

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        using (var tester = new Tester(_sampleFilePath, _problemNumber, prblemLevel))
        {
            var problem = new ProblemE(tester.Reader, tester.Writer);
            Action method = problem.Solve;

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(method);
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif

#if false
    [Fact]
    public void SolveF()
    {
        var prblemLevel = $"F";

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        using (var tester = new Tester(_sampleFilePath, _problemNumber, prblemLevel))
        {
            var problem = new ProblemF(tester.Reader, tester.Writer);
            Action method = problem.Solve;

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(method);
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif

#if false
    [Fact]
    public void SolveG()
    {
        var prblemLevel = $"G";

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        using (var tester = new Tester(_sampleFilePath, _problemNumber, prblemLevel))
        {
            var problem = new ProblemG(tester.Reader, tester.Writer);
            Action method = problem.Solve;

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(method);
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif
}