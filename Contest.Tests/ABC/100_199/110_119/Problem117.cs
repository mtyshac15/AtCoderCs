using AtCoderCs.Contest.ABC117;
using Contest.Tests;
using System.Reflection;

namespace AtCoderCs.Contest.Tests.ABC117;

[TestClass]
public class Problem
{
    private static readonly string _contestSection = $"ABC";
    private static readonly string _problemFolder = Path.Combine($"100_199", "110_119");
    private static readonly string _problemNumber = $"117";

    private static readonly string _sampleFilePath = Path.Combine($"{_contestSection}", $"{_problemFolder}", $"{_problemNumber}");

#if Practice
    [TestMethod]
    public void SolveA()
    {
        var prblemLevel = $"A";

        var problem = new ProblemA();
        Action method = problem.Solve;

        var epsilon = 0.001;
        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method, epsilon);
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