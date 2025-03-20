using AtCoderCs.Contest.ABC001.ProblemA;
using AtCoderCs.Contest.ABC001.ProblemB;
using AtCoderCs.Contest.ABC001.ProblemC;
using AtCoderCs.Contest.ABC001.ProblemD;
using AtCoderCsTest.Contents.Services;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Xunit.Abstractions;

namespace AtCoderCs.Contest.Tests.ABC001;

[Contest($"ABC", $"001")]
[Sample($"ABC", $"000_099", "000_009", $"001")]
public class TestProblem : IClassFixture<TestFixture>
{
    private static readonly ContestAttribute _contestAttribute = typeof(TestProblem).GetCustomAttribute<ContestAttribute>()!;
    private static readonly SampleAttribute _sampleAttribute = typeof(TestProblem).GetCustomAttribute<SampleAttribute>()!;

    private ILogger _logger;
    private ISampleRepository _sampleRepository;
    private TestJudgeService _judgeService;

    public TestProblem(ITestOutputHelper output, TestFixture fixture)
    {
        _logger = new XunitLogger(output);
        _sampleRepository = fixture.GetSampleRepository(_sampleAttribute.Directory);
        _judgeService = new TestJudgeService(_logger);
    }

#if DEBUG
    [Theory(DisplayName = $"ABC 001")]
    [Trait("Contest", "ABC")]
    [InlineData($"A", typeof(ProblemA), nameof(ProblemA.Solve))]
    [InlineData($"B", typeof(ProblemB), nameof(ProblemB.Solve))]
    [InlineData($"C", typeof(ProblemC), nameof(ProblemC.Solve))]
    [InlineData($"D", typeof(ProblemD), nameof(ProblemD.Solve))]
    public void Solve(string level, Type problemType, string methodName, double epcilon = 0)
    {
        var sample = _sampleRepository.Find(_contestAttribute.Number, level);
        var results = _judgeService.Solve(sample, problemType, methodName);
        _judgeService.Judge(results, epcilon);
    }
#endif
}