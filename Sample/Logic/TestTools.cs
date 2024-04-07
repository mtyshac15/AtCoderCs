using System.Data;
using System.Text;

namespace Sample.Logic
{
    public static class TestTools
    {
        private static readonly string _inputFileName = "Input.txt";
        private static readonly string _outputFileName = "Output.txt";

        public static IList<(string Expected, string Actual)> TestInOut(string sampleFolder, string number, string problemLevel, Action method)
        {
            var inputFilePath = Path.Combine($"{sampleFolder}", $"{number}{problemLevel}_{_inputFileName}");
            var outputFilePath = Path.Combine($"{sampleFolder}", $"{number}{problemLevel}_{_outputFileName}");

            //�o�͗��ǂݍ���
            var expectedDic = TestTools.ReadOutput(outputFilePath);

            //���s����
            var actualDic = TestTools.Execute(inputFilePath, method);

            var list = expectedDic.Join(actualDic,
                                        e => e.Key,
                                        a => a.Key,
                                        (e, a) => new
                                        {
                                            Expected = e.Value,
                                            Actual = a.Value
                                        })
                                   .Select(x => (x.Expected, x.Actual))
                                   .ToList();

            return list;
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