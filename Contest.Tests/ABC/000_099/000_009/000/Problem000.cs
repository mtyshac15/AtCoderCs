using AtCoderCs.Contest.ABC000;
using Contest.Tests;
using System.Reflection;

namespace AtCoderCs.Contest.Tests.ABC000;

[TestClass]
public class Problem
{
    private static readonly string _contestSection = $"ABC";
    private static readonly string _problemFolder = Path.Combine($"000_099", "000_009");
    private static readonly string _problemNumber = $"000";

    private static readonly string _sampleFilePath = Path.Combine($"{_contestSection}", $"{_problemFolder}", $"{_problemNumber}", $"Sample");

#if None
    [TestMethod]
    public void SolveA()
    {
        var prblemLevel = $"A";

        var problem = new ProblemA();
        Action method = problem.Solve;

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif

#if None
    [TestMethod]
    public void SolveB()
    {
        var prblemLevel = $"B";

        var problem = new ProblemB();
        Action method = problem.Solve;

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif

#if None
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

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif

#if None
    [TestMethod]
    public void SolveE()
    {
        var prblemLevel = $"E";

        var problem = new ProblemE();
        Action method = problem.Solve;

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif

#if None
    [TestMethod]
    public void SolveF()
    {
        var prblemLevel = $"F";

        var problem = new ProblemF();
        Action method = problem.Solve;

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif
}