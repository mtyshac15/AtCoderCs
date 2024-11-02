using AtCoderCs.Common.Library;
using AtCoderCs.Contest.ABC142;
using AtCoderCs.Contest.Tests;
using Contest.Tests.Modules;
using System.Reflection;
using Xunit;

namespace AtCoderCs.Contest.Tests.ABC142;

[Contest($"ABC", $"142")]
public class Problem : IClassFixture<TestFixture>
{
    private static readonly ContestAttribute _attribute = Attribute.GetCustomAttribute(typeof(Problem), typeof(ContestAttribute)) as ContestAttribute;
    private static readonly string _problemFolder = Path.Combine($"100_199", "140_149");

    private TestFixture _fixture;

    public Problem(TestFixture fixture)
    {
        _fixture = fixture;
        _fixture.ConfigureSampleFolder(_attribute.Section, _problemFolder, _attribute.Number);
    }

#if true
    [Theory(DisplayName = $"ABC 142")]
    [InlineData($"A", typeof(ProblemA), nameof(ProblemA.Solve), 0.000001)]
    //[InlineData($"B", typeof(ProblemB), nameof(ProblemB.Solve))]
    [InlineData($"C", typeof(ProblemC), nameof(ProblemC.Solve))]
    //[InlineData($"D", typeof(ProblemD), nameof(ProblemD.Solve))]
    //[InlineData($"E", typeof(ProblemE), nameof(ProblemE.Solve))]
    //[InlineData($"F", typeof(ProblemF), nameof(ProblemF.Solve))]
    public void Solve(string level, Type problemType, string methodName, double epcilon = 0)
    {
        var sample = _fixture.ReadFiles(_attribute.Number, level);
        TestTools.Solve(sample, problemType, methodName, epcilon);
    }
#endif
}