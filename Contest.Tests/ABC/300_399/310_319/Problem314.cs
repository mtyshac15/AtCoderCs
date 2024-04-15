using AtCoderCs.Contest.ABC314;
using AtCoderCs.Contest.Tests;
using System.Reflection;
using Xunit;

namespace AtCoderCs.Contest.Tests.ABC314;

public class Problem
{
    private static readonly string _contestSection = $"ABC";
    private static readonly string _problemFolder = Path.Combine($"300_399", "310_319");
    private static readonly string _problemNumber = $"314";

    private static readonly string _sampleFilePath = Path.Combine($"{_contestSection}", $"{_problemFolder}", $"{_problemNumber}");

#if Accepted
    [Fact]
    public void SolveA()
    {
        var prblemLevel = $"A";

        var problem = new ProblemA();
        Action method = problem.Solve;

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif

#if Accepted
    [Fact]
    public void SolveB()
    {
        var prblemLevel = $"B";

        var problem = new ProblemB();
        Action method = problem.Solve;

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif

#if Practice
    [Fact]
    public void SolveC()
    {
        var prblemLevel = $"C";

        var problem = new ProblemC();
        Action method = problem.Solve;

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif

#if None
    [Fact]
    public void SolveD()
    {
        var prblemLevel = $"D";

        var problem = new ProblemD();
        Action method = problem.Solve;

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif

#if None
    [Fact]
    public void SolveE()
    {
        var prblemLevel = $"E";

        var problem = new ProblemE();
        Action method = problem.Solve;

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif

#if None
    [Fact]
    public void SolveF()
    {
        var prblemLevel = $"F";

        var problem = new ProblemF();
        Action method = problem.Solve;

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif
}