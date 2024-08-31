using AtCoderCs.Common.Library;
using AtCoderCs.Contest.ABC353;
using AtCoderCs.Contest.Tests;
using System.Reflection;
using Xunit;

namespace AtCoderCs.Contest.Tests.ABC353;

public class Problem : IClassFixture<TestFixture>
{
    private static readonly string _contestSection = $"ABC";
    private static readonly string _problemFolder = Path.Combine($"300_399", "350_359");
    private static readonly string _problemNumber = $"353";

    private TestFixture _fixture;

    public Problem(TestFixture fixture)
    {
        _fixture = fixture;
        _fixture.ConfigureSampleFolder(_contestSection, _problemFolder, _problemNumber);
    }

#if true
    [Theory(DisplayName = $"ABC 353")]
    [InlineData($"A", typeof(ProblemA), nameof(ProblemA.Solve))]
    [InlineData($"B", typeof(ProblemB), nameof(ProblemB.Solve))]
    [InlineData($"C", typeof(ProblemC), nameof(ProblemC.Solve))]
    [InlineData($"D", typeof(ProblemD), nameof(ProblemD.Solve))]
    [InlineData($"E", typeof(ProblemE), nameof(ProblemE.Solve))]
    [InlineData($"F", typeof(ProblemF), nameof(ProblemF.Solve))]
    [InlineData($"G", typeof(ProblemG), nameof(ProblemG.Solve))]
    public void Solve(string level, Type problemType, string methodName)
    {
        var sample = _fixture.ReadFiles(_problemNumber, level);
        TestTools.Solve(sample, problemType, methodName);
    }
#endif
}