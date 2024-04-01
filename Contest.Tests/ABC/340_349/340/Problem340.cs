
using AtCoderCs.Contest.ABC000;
using System.Reflection;

namespace AtCoderCs.Contest.Tests.ABC340
{
    [TestClass]
    public class Problem
    {
        private static readonly string _contestSection = $"ABC";
        private static readonly string _problemFolder = Path.Combine($"340_349");
        private static readonly string _problemNumber = $"340";

        private static readonly string _sampleFilePath = Path.Combine($"{_contestSection}", $"{_problemFolder}", $"{_problemNumber}", $"Sample");

        private string _consoleOutput;

        [TestMethod]
        public void SolveA()
        {
            var prblemLevel = $"A";

            var inputFile = $"Input{prblemLevel}.txt";
            var inputFilePath = Path.Combine($"{_sampleFilePath}", $"{inputFile}");

            var outputFile = $"Output{prblemLevel}.txt";
            var outputFilePath = Path.Combine($"{_sampleFilePath}", $"{inputFile}");

            var problem = new AtCoderCs.Contest.ABC340.ProblemA();
            Action method = problem.Solve;

            Problem.TestInOut(inputFilePath, outputFilePath, method);
        }

        public static void TestInOut(string inputFile, string outputFile, Action method)
        {
            using (var input = new StreamReader(inputFile))
            using (var output = new StringWriter())
            {
                Console.SetIn(input);
                Console.SetOut(output);

                var sampleNum = int.Parse(Console.ReadLine());
                for (int i = 0; i < sampleNum; i++)
                {
                    method?.Invoke();

                    //���s���邽�тɁA���s���o��
                    Console.WriteLine();

                    //�󗓍s����s�ǂݍ���
                    Console.ReadLine();
                }

                var expectedText = File.ReadAllText(outputFile);
                var actualText = output.ToString();
                Assert.AreEqual(expectedText, actualText);
            }
        }
    }
}