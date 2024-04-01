
using System.Reflection;

namespace AtCoderCs.Contest.Tests.ABC339
{
    [TestClass]
    public class Problem
    {
        private static readonly string _contestSection = $"ABC";
        private static readonly string _problemFolder = Path.Combine($"300_399", "330_339");
        private static readonly string _problemNumber = $"339";

        private static readonly string _sampleFilePath = Path.Combine($"{_contestSection}", $"{_problemFolder}", $"{_problemNumber}", $"Sample");

        [TestMethod]
        public void SolveA()
        {
            var prblemLevel = $"A";

            var problem = new AtCoderCs.Contest.ABC339.ProblemA();
            Action method = problem.Solve;
        }
    }
}