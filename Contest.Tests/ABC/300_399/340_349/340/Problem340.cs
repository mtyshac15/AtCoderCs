
using AtCoderCs.Contest.ABC000;
using Contest.Tests;
using System.Reflection;

namespace AtCoderCs.Contest.Tests.ABC340
{
    [TestClass]
    public class Problem
    {
        private static readonly string _contestSection = $"ABC";
        private static readonly string _problemFolder = Path.Combine($"300_399", "340_349");
        private static readonly string _problemNumber = $"340";

        private static readonly string _sampleFilePath = Path.Combine($"{_contestSection}", $"{_problemFolder}", $"{_problemNumber}", $"Sample");

#if Practice
        [TestMethod]
        public void SolveA()
        {
            var prblemLevel = $"A";

            var problem = new AtCoderCs.Contest.ABC340.ProblemA();
            Action method = problem.Solve;

            //TestTools.TestInOut(_sampleFilePath, _problemNumber, prblemLevel, method);
        }
#endif
    }
}