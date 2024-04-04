using AtCoderCs.Contest.ABC088;
using Contest.Tests;
using System.Reflection;

namespace AtCoderCs.Contest.Tests.ABC088
{
    [TestClass]
    public class Problem
    {
        private static readonly string _contestSection = $"ABC";
        private static readonly string _problemFolder = Path.Combine($"000_099", "000_009");
        private static readonly string _problemNumber = $"000";

        private static readonly string _sampleFilePath = Path.Combine($"{_contestSection}", $"{_problemFolder}", $"{_problemNumber}", $"Sample");

#if Accepted
        [TestMethod]
        public void SolveA()
        {
            var prblemLevel = $"A";

            var problem = new ProblemA();
            Action method = problem.Solve;

            TestTools.TestInOut(_sampleFilePath, _problemNumber, prblemLevel, method);
        }
#endif

#if Accepted
        [TestMethod]
        public void SolveB()
        {
            var prblemLevel = $"B";

            var problem = new ProblemB();
            Action method = problem.Solve;

            TestTools.TestInOut(_sampleFilePath, _problemNumber, prblemLevel, method);
        }
#endif


#if None
        [TestMethod]
        public void SolveC()
        {
            var prblemLevel = $"C";

            var problem = new ProblemC();
            Action method = problem.Solve;

            //TestTools.TestInOut(_sampleFilePath, _problemNumber, prblemLevel, method);
        }
#endif

#if None
        [TestMethod]
        public void SolveD()
        {
            var prblemLevel = $"D";

            var problem = new ProblemD();
            Action method = problem.Solve;

            //TestTools.TestInOut(_sampleFilePath, _problemNumber, prblemLevel, method);
        }
#endif
    }
}