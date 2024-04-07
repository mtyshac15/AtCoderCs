using AtCoderCs.Contest.ABC253;
using Contest.Tests;
using System.Reflection;

namespace AtCoderCs.Contest.Tests.ABC253;

[TestClass]
public class Problem
{
    private static readonly string _contestSection = $"ABC";
    private static readonly string _problemFolder = Path.Combine($"200_299", "250_259");
    private static readonly string _problemNumber = $"253";

    private static readonly string _sampleFilePath = Path.Combine($"{_contestSection}", $"{_problemFolder}", $"{_problemNumber}", $"Sample");

#if Practice
    [TestMethod]
    public void SolveA()
    {
        var prblemLevel = $"A";

        var problem = new ProblemA();
        Action method = problem.Solve;

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif

#if Practice
    [TestMethod]
    public void SolveB()
    {
        var prblemLevel = $"B";

        var problem = new ProblemB();
        Action method = problem.Solve;

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif

#if Practice
    [TestMethod]
    public void SolveC()
    {
        var prblemLevel = $"C";

        var problem = new ProblemC();
        Action method = problem.Solve;

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif

#if None
    [TestMethod]
    public void SolveD()
    {
        var prblemLevel = $"D";

        var problem = new ProblemD();
        Action method = problem.Solve;

        TestTools.TestInOut(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif

#if None
    [TestMethod]
    public void SolveE()
    {
        var prblemLevel = $"E";

        var problem = new ProblemE();
        Action method = problem.Solve;

        TestTools.TestInOut(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif

#if None
    [TestMethod]
    public void SolveF()
    {
        var prblemLevel = $"F";

        var problem = new ProblemF();
        Action method = problem.Solve;

        TestTools.TestInOut(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif
}