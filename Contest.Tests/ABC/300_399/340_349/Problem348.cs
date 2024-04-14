using AtCoderCs.Common.Library;
using AtCoderCs.Contest.ABC348;
using AtCoderCs.Contest.Tests;
using System.Reflection;
using Xunit;

namespace AtCoderCs.Contest.Tests.ABC348;

public class Problem
{
    private static readonly string _contestSection = $"ABC";
    private static readonly string _problemFolder = Path.Combine($"300_399", "340_349");
    private static readonly string _problemNumber = $"348";

    private static readonly string _sampleFilePath = Path.Combine($"{_contestSection}", $"{_problemFolder}", $"{_problemNumber}");

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

            expectedDic = tester.Execute(method);
            actualDic = tester.ReadOutputSample();
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif

#if Practice
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

            expectedDic = tester.Execute(method);
            actualDic = tester.ReadOutputSample();
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif

#if Practice
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

            expectedDic = tester.Execute(method);
            actualDic = tester.ReadOutputSample();
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif

#if Practice
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

            expectedDic = tester.Execute(method);
            actualDic = tester.ReadOutputSample();
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

            expectedDic = tester.Execute(method);
            actualDic = tester.ReadOutputSample();
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

            expectedDic = tester.Execute(method);
            actualDic = tester.ReadOutputSample();
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

            expectedDic = tester.Execute(method);
            actualDic = tester.ReadOutputSample();
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif
}