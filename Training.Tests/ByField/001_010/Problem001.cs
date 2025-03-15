using Microsoft.Extensions.Logging;
using System.Reflection;
using Tests.Contents.Services;
using Training.ByField100.Problem001;
using Xunit;
using Xunit.Abstractions;

namespace Training.Tests.ByField.Problem001
{
    [Contest($"ByField100", $"")]
    public class Problem001 : IClassFixture<TestFixture>
    {
        private static readonly ContestAttribute _attribute = typeof(Problem001).GetCustomAttribute<ContestAttribute>();
        private static readonly string _problemFolder = $"001_010";

        private ILogger _logger;
        private TestJudgeService _judgeService;

        public Problem001(ITestOutputHelper output, TestFixture fixture)
        {
            _logger = new XunitLogger(output);
            var baseDirectory = fixture.GetBaseDirectory(_attribute.Section, _problemFolder, _attribute.Number);
            _judgeService = new TestJudgeService(_logger, baseDirectory, _attribute.Number);
        }

#if true
        [Theory(DisplayName = $"ByField 001")]
        [InlineData($"001", typeof(Problem), nameof(Problem.Solve))]
        public void Solve(string level, Type problemType, string methodName, double epcilon = 0)
        {
            var results = _judgeService.Solve(level, problemType, methodName);
            _judgeService.Judge(results, epcilon);
        }
#endif
    }
}
