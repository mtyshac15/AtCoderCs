using AtCoderCs.Common.Library;
using AtCoderCs.Contest.ABC043;
using AtCoderCs.Contest.Tests;
using System.Reflection;
using Xunit;

namespace AtCoderCs.Contest.Tests.ABC043;

public class Problem
{
    private static readonly string _contestSection = $"ABC";
    private static readonly string _problemFolder = Path.Combine($"000_099", "040_049");
    private static readonly string _problemNumber = $"043";

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

            expectedDic = tester.Execute(method);
            actualDic = tester.ReadOutputSample();
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

            expectedDic = tester.Execute(method);
            actualDic = tester.ReadOutputSample();
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

            expectedDic = tester.Execute(method);
            actualDic = tester.ReadOutputSample();
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif
}