using System.Data;
using System.Text;

namespace Contest.Tests
{
    public static class TestTools
    {
        private static readonly string _inputFileName = "Input.txt";
        private static readonly string _outputFileName = "Output.txt";

        public static void TestInOut(string sampleFolder, string number, string problemLevel, Action method, double epsilon = 0)
        {
            var inputFilePath = Path.Combine($"{sampleFolder}", $"{number}{problemLevel}_{_inputFileName}");
            var outputFilePath = Path.Combine($"{sampleFolder}", $"{number}{problemLevel}_{_outputFileName}");

            //出力例を読み込む
            var expectedDic = TestTools.ReadOutput(outputFilePath);

            //実行結果
            var actualDic = TestTools.Execute(inputFilePath, method);

            if (epsilon > 0)
            {
                foreach (var actual in actualDic)
                {
                    //誤差あり
                    var expected = expectedDic[actual.Key];

                    var actuaValues = actual.Value.Split();
                    var expectedValues = expected.Split();

                    foreach (var item in actuaValues.Zip(expectedValues))
                    {
                        double actualValue;
                        double expectedValue;

                        double.TryParse(item.First, out actualValue);
                        double.TryParse(item.Second, out expectedValue);

                        var sub = Math.Abs(actualValue - expectedValue);
                        Assert.IsTrue(sub < epsilon);
                    }
                }
            }
            else
            {
                foreach (var actual in actualDic)
                {
                    var expected = expectedDic[actual.Key];
                    Assert.AreEqual(expected, actual.Value);
                }
            }
        }

        private static IDictionary<int, string> ReadOutput(string outputFilePath)
        {
            var expectedDic = new Dictionary<int, string>();
            using (var reader = new StreamReader(outputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    //サンプル番号
                    var sampleNumber = int.Parse(reader.ReadLine());

                    var strBuilder = new StringBuilder();
                    while (true)
                    {
                        //空欄行まで読み込む
                        var line = reader.ReadLine();
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            strBuilder.AppendLine(line);
                        }
                        else
                        {
                            //空欄を読み込んだ場合は、そこまでが1サンプルの出力例

                            //末尾にある改行コードをすべて削除
                            var expectedOutputStr = strBuilder.ToString().TrimEnd('\r', '\n');

                            //末尾に改行コードを一つだけ追加
                            var formatBuilder = new StringBuilder();
                            formatBuilder.AppendLine(expectedOutputStr);

                            expectedDic.Add(sampleNumber, formatBuilder.ToString());
                            break;
                        }
                    }
                }
            }

            return expectedDic;
        }

        private static IDictionary<int, string> Execute(string inputFilePath, Action method)
        {
            var actualDic = new Dictionary<int, string>();
            using (var input = new StreamReader(inputFilePath))
            {
                Console.SetIn(input);

                while (!input.EndOfStream)
                {
                    using (var output = new StringWriter())
                    {
                        Console.SetOut(output);

                        var text = Console.ReadLine();
                        var inputNumber = int.Parse(text);

                        method?.Invoke();

                        //末尾にある改行コードをすべて削除
                        var outputStr = output.ToString().TrimEnd('\r', '\n');

                        //末尾に改行コードを一つだけ追加
                        var strBuilder = new StringBuilder();
                        strBuilder.AppendLine(outputStr);

                        actualDic.Add(inputNumber, strBuilder.ToString());
                    }

                    //空欄行出なかった場合、空欄行まで読み込む
                    var extraLine = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(extraLine))
                    {
                        while (true)
                        {
                            //空欄行を読み込んだら処理を終了する
                            extraLine = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(extraLine))
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return actualDic;
        }
    }
}