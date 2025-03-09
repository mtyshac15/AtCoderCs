using AtCoderCs.Contest.ABC038;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Tests.Contents.Services;
using Xunit;
using Xunit.Abstractions;

namespace AtCoderCs.Contest.Tests.ABC038;

[Contest($"ABC", $"038")]
public class Problem : IClassFixture<TestFixture>
{
    private static readonly ContestAttribute _attribute = typeof(Problem).GetCustomAttribute<ContestAttribute>();
    private static readonly string _problemFolder = Path.Combine($"000_099", "030_039");

    private ILogger _logger;
    private TestJudgeService _judgeService;

    public Problem(ITestOutputHelper output, TestFixture fixture)
    {
        _logger = new XunitLogger(output);
        var baseDirectory = fixture.GetBaseDirectory(_attribute.Section, _problemFolder, _attribute.Number);
        _judgeService = new TestJudgeService(_logger, baseDirectory, _attribute.Number);
    }

#if false
    [Theory(DisplayName = $"ABC 038")]
    [InlineData($"A", typeof(ProblemA), nameof(ProblemA.Solve))]
    //[InlineData($"B", typeof(ProblemB), nameof(ProblemB.Solve))]
    //[InlineData($"C", typeof(ProblemC), nameof(ProblemC.Solve))]
    //[InlineData($"D", typeof(ProblemD), nameof(ProblemD.Solve))]
    public void Solve(string level, Type problemType, string methodName, double epcilon = 0)
    {
        var sample = _fixture.ReadFiles(_attribute.Number, level);
        var results = TestTools.Solve(sample, problemType, methodName);
        TestTools.Judge(_logger, results, epcilon);
    }
#endif
}