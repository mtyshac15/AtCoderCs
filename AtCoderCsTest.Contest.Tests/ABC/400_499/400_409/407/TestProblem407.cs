using AtCoderCs.Contest.ABC407.ProblemA;
using AtCoderCs.Contest.ABC407.ProblemB;
using AtCoderCs.Contest.ABC407.ProblemC;
using AtCoderCs.Contest.ABC407.ProblemD;
using AtCoderCs.Contest.ABC407.ProblemE;
using AtCoderCs.Contest.ABC407.ProblemF;
using AtCoderCs.Contest.ABC407.ProblemG;
using AtCoderCsTest.Contents.Services;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Xunit.Abstractions;

namespace AtCoderCs.Contest.Tests.ABC407;

[Contest($"ABC", $"407")]
[Sample($"ABC", $"400_499", "400_409", $"407")]
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
  [Theory(DisplayName = $"ABC 407")]
  [Trait("Contest", "ABC")]
  [InlineData($"A", typeof(ProblemA), nameof(ProblemA.Solve))]
  [InlineData($"B", typeof(ProblemB), nameof(ProblemB.Solve), 10, -9)]
  [InlineData($"C", typeof(ProblemC), nameof(ProblemC.Solve))]
  [InlineData($"D", typeof(ProblemD), nameof(ProblemD.Solve))]
  [InlineData($"E", typeof(ProblemE), nameof(ProblemE.Solve))]
  [InlineData($"F", typeof(ProblemF), nameof(ProblemF.Solve))]
  [InlineData($"G", typeof(ProblemG), nameof(ProblemG.Solve))]
  public void Solve(string level, Type problemType, string methodName, int radix = 10, int exp = 0)
  {
    var sample = _sampleRepository.Find(_contestAttribute.Number, level);
    var results = _judgeService.Solve(sample, problemType, methodName);
    _judgeService.Judge(results, radix, exp);
  }
#endif
}