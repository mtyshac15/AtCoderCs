using AtCoderCs.Common.Library;
using AtCoderCs.Contest.ABC171;
using AtCoderCs.Contest.Tests;
using Contest.Tests.Services;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AtCoderCs.Contest.Tests.ABC171;

[Contest($"ABC", $"171")]
public class Problem : IClassFixture<TestFixture>
{
    private static readonly ContestAttribute _attribute = Attribute.GetCustomAttribute(typeof(Problem), typeof(ContestAttribute)) as ContestAttribute;
    private static readonly string _problemFolder = Path.Combine($"100_199", "170_179");

    private ITestOutputHelper _output;
    private ILogger _logger;
    private TestFixture _fixture;

    public Problem(ITestOutputHelper output, TestFixture fixture)
    {
        _logger = new XunitLogger(output);
        _output = output;
        _fixture = fixture;
        _fixture.ConfigureSampleFolder(_attribute.Section, _problemFolder, _attribute.Number);
    }

#if false
    [Theory(DisplayName = $"ABC 171")]
    [InlineData($"A", typeof(ProblemA), nameof(ProblemA.Solve))]
    [InlineData($"B", typeof(ProblemB), nameof(ProblemB.Solve))]
    //[InlineData($"C", typeof(ProblemC), nameof(ProblemC.Solve))]
    //[InlineData($"D", typeof(ProblemD), nameof(ProblemD.Solve))]
    //[InlineData($"E", typeof(ProblemE), nameof(ProblemE.Solve))]
    //[InlineData($"F", typeof(ProblemF), nameof(ProblemF.Solve))]
    //[InlineData($"G", typeof(ProblemG), nameof(ProblemG.Solve))]
    public void Solve(string level, Type problemType, string methodName, double epcilon = 0)
    {
        var sample = _fixture.ReadFiles(_attribute.Number, level);
        var results = TestTools.Solve(sample, problemType, methodName);
        TestTools.Judge(_logger, results, epcilon);
    }
#endif
}