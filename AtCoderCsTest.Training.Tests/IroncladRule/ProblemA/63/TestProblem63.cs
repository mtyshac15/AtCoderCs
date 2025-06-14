using AtCoderCs.Training.A63;
using AtCoderCsTest.Contents.Services;
using AtCoderCsTest.Training.Tests.Services;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Xunit.Abstractions;

namespace AtCoderCs.Training.Tests.A63;

[Collection(nameof(TrainingTestCollection))]
[Contest($"IroncladRule", $"63")]
[Sample($"IroncladRule", $"ProblemA", $"63")]
public class TestProblem
{
  private static readonly ContestAttribute _contestAttribute = typeof(TestProblem).GetCustomAttribute<ContestAttribute>()!;
  private static readonly SampleAttribute _sampleAttribute = typeof(TestProblem).GetCustomAttribute<SampleAttribute>()!;

  private ILogger _logger;
  private ISampleRepository _sampleRepository;
  private TestJudgeService _judgeService;

  public TestProblem(ITestOutputHelper output, TrainingTestFixture fixture)
  {
    _logger = new XunitLogger(output);
    _sampleRepository = fixture.GetSampleRepository(_sampleAttribute.Directory);
    _judgeService = new TestJudgeService(_logger);
  }

#if DEBUG
  [Theory(DisplayName = $"IroncladRule 63")]
  [InlineData($"", typeof(ProblemA), nameof(ProblemA.Solve))]
  public void Solve(string level, Type problemType, string methodName, int radix = 10, int exp = 0)
  {
    var sample = _sampleRepository.Find(_contestAttribute.Number, level);
    var results = _judgeService.Solve(sample, problemType, methodName);
    _judgeService.Judge(results, radix, exp);
  }
#endif
}
