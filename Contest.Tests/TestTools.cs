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

            //�o�͗��ǂݍ���
            var expectedDic = TestTools.ReadOutput(outputFilePath);

            //���s����
            var actualDic = TestTools.Execute(inputFilePath, method);

            if (epsilon > 0)
            {
                foreach (var actual in actualDic)
                {
                    //�덷����
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
                    //�T���v���ԍ�
                    var sampleNumber = int.Parse(reader.ReadLine());

                    var strBuilder = new StringBuilder();
                    while (true)
                    {
                        //�󗓍s�܂œǂݍ���
                        var line = reader.ReadLine();
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            strBuilder.AppendLine(line);
                        }
                        else
                        {
                            //�󗓂�ǂݍ��񂾏ꍇ�́A�����܂ł�1�T���v���̏o�͗�

                            //�����ɂ�����s�R�[�h�����ׂč폜
                            var expectedOutputStr = strBuilder.ToString().TrimEnd('\r', '\n');

                            //�����ɉ��s�R�[�h��������ǉ�
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

                        //�����ɂ�����s�R�[�h�����ׂč폜
                        var outputStr = output.ToString().TrimEnd('\r', '\n');

                        //�����ɉ��s�R�[�h��������ǉ�
                        var strBuilder = new StringBuilder();
                        strBuilder.AppendLine(outputStr);

                        actualDic.Add(inputNumber, strBuilder.ToString());
                    }

                    //�󗓍s�o�Ȃ������ꍇ�A�󗓍s�܂œǂݍ���
                    var extraLine = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(extraLine))
                    {
                        while (true)
                        {
                            //�󗓍s��ǂݍ��񂾂珈�����I������
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