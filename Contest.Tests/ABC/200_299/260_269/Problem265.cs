using AtCoderCs.Common.Library;
using AtCoderCs.Contest.ABC265;
using AtCoderCs.Contest.Tests;
using Contest.Tests.Services;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace AtCoderCs.Contest.Tests.ABC265;

[Contest($"ABC", $"265")]
public class Problem : IClassFixture<TestFixture>
{
    private static readonly ContestAttribute _attribute = Attribute.GetCustomAttribute(typeof(Problem), typeof(ContestAttribute)) as ContestAttribute;

    private static readonly string _problemFolder = Path.Combine($"200_299", "260_269");

    private TestFixture _fixture;

    public Problem(TestFixture fixture)
    {
        _fixture = fixture;
        _fixture.ConfigureSampleFolder(_attribute.Section, _problemFolder, _attribute.Number);
    }

#if false
    [Theory(DisplayName = $"ABC 265")]
    [InlineData($"A", typeof(ProblemA), nameof(ProblemA.Solve))]
    [InlineData($"B", typeof(ProblemB), nameof(ProblemB.Solve))]
    //[InlineData($"C", typeof(ProblemC), nameof(ProblemC.Solve))]
    //[InlineData($"D", typeof(ProblemD), nameof(ProblemD.Solve))]
    //[InlineData($"E", typeof(ProblemE), nameof(ProblemE.Solve))]
    //[InlineData($"F", typeof(ProblemF), nameof(ProblemF.Solve))]
    //[InlineData($"G", typeof(ProblemG), nameof(ProblemG.Solve))]
    public void Solve(string level, Type problemType, string methodName)
    {
        var sample = _fixture.ReadFiles(_attribute.Number, level);
        TestTools.Solve(sample, problemType, methodName);
    }
#endif
}