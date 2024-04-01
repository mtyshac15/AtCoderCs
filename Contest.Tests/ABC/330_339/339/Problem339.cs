
using System.Reflection;

namespace AtCoderCs.Contest.Tests.ABC339
{
    [TestClass]
    public class Problem
    {
        private static readonly string _contestSection = $"ABC";
        private static readonly string _problemFolder = Path.Combine($"330_339");
        private static readonly string _problemNumber = $"339";

        private static readonly string _sampleFilePath = Path.Combine($"{_contestSection}", $"{_problemFolder}", $"{_problemNumber}", $"Sample");

        private string _consoleOutput;



        [TestInitialize]
        public void Initialize()
        {
            var inputFile = $"InputA.txt";

            var path = Path.Combine($"{_sampleFilePath}", $"{inputFile}");
            var exStdIn = new System.IO.StreamReader(path);
            System.Console.SetIn(exStdIn);

            var w = new System.IO.StringWriter();
            Console.SetOut(w);

            Program.Main(new string[0]);

            _consoleOutput = w.GetStringBuilder().ToString().Trim();
        }

        [TestMethod]
        public void SolveA()
        {
            var sampleNum = int.Parse(Console.ReadLine());
            var problem = new AtCoderCs.Contest.ABC339.ProblemA();
            //problem.Solve();
        }
    }
}