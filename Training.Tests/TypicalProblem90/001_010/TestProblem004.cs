using AtCoderCs.Traing.Typical.Problem004;
using AtCoderCs.Training.Tests;
using Xunit;

namespace AtCoderCs.Traing.Typical.Tests.Problem004;

public class TestProblem
{
    private static readonly string _contestSection = $"TypicalProblem90";
    private static readonly string _problemFolder = $"001_010";
    private static readonly string _problemNumber = $"004";

    private static readonly string _sampleFilePath = Path.Combine($"{_contestSection}", $"{_problemFolder}", $"{_problemNumber}");

#if Training
    [Fact]
    public void Solve()
    {
        var prblemLevel = string.Empty;

        var problem = new Problem();
        Action method = problem.Solve;

        //TestTools.Judge(_sampleFilePath, _problemNumber, prblemLevel, method);
    }
#endif
}