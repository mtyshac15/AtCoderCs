using AtCoderCs.Traing.Typical.Problem001;
using AtCoderCs.Training.Tests;

namespace AtCoderCs.Traing.Typical.Tests.Problem000;

public class TestProblem
{
    private static readonly string _contestSection = $"TypicalProblem90";
    private static readonly string _problemFolder = $"001_010";
    private static readonly string _problemNumber = $"000";

    private static readonly string _sampleFilePath = Path.Combine($"{_contestSection}", $"{_problemFolder}", $"{_problemNumber}");

#if false
    [Fact]
    public void Solve()
    {
        var prblemLevel = string.Empty;

        var problem = new Problem();
        Action method = problem.Solve;

        TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif
}