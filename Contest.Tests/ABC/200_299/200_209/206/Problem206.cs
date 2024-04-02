using AtCoderCs.Contest.ABC206;
using Contest.Tests;
using System.Reflection;

namespace AtCoderCs.Contest.Tests.ABC206
{
    [TestClass]
    public class Problem
    {
#if Practice
        private static readonly string _contestSection = $"ABC";
        private static readonly string _problemFolder = Path.Combine($"200_299", "200_209");
        private static readonly string _problemNumber = $"206";

        private static readonly string _sampleFilePath = Path.Combine($"{_contestSection}", $"{_problemFolder}", $"{_problemNumber}", $"Sample");

        [TestMethod]
        public void SolveA()
        {
            var prblemLevel = $"A";

            var problem = new ProblemA();
            Action method = problem.Solve;

            TestTools.TestInOut(_sampleFilePath, _problemNumber, prblemLevel, method);
        }

        [TestMethod]
        public void SolveB()
        {
            var prblemLevel = $"B";

            var problem = new ProblemB();
            Action method = problem.Solve;

            //TestTools.TestInOut(_sampleFilePath, _problemNumber, prblemLevel, method);
        }

        [TestMethod]
        public void SolveC()
        {
            var prblemLevel = $"C";

            var problem = new ProblemC();
            Action method = problem.Solve;

            //TestTools.TestInOut(_sampleFilePath, _problemNumber, prblemLevel, method);
        }

        [TestMethod]
        public void SolveD()
        {
            var prblemLevel = $"D";

            var problem = new ProblemD();
            Action method = problem.Solve;

            //TestTools.TestInOut(_sampleFilePath, _problemNumber, prblemLevel, method);
        }

        [TestMethod]
        public void SolveE()
        {
            var prblemLevel = $"E";

            var problem = new ProblemE();
            Action method = problem.Solve;

            //TestTools.TestInOut(_sampleFilePath, _problemNumber, prblemLevel, method);
        }

        [TestMethod]
        public void SolveF()
        {
            var prblemLevel = $"F";

            var problem = new ProblemF();
            Action method = problem.Solve;

            //TestTools.TestInOut(_sampleFilePath, _problemNumber, prblemLevel, method);
        }
#endif
    }
}