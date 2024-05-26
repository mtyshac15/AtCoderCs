using AtCoderCs.Common.Library;
using AtCoderCs.Traing.Typical.Problem001;
using AtCoderCs.Training.Tests;
using Xunit;

namespace AtCoderCs.Traing.Typical.Tests.Problem001;

public class TestProblem
{
    private static readonly string _contestSection = $"TypicalProblem90";
    private static readonly string _problemFolder = $"001_010";
    private static readonly string _problemNumber = $"001";

    private SampleFiePath _sampleFiePath;

    public TestProblem()
    {
        _sampleFiePath = new SampleFiePath(_contestSection, _problemFolder, _problemNumber);
    }

#if true
    [Fact]
    public void Solve()
    {
        var prblemLevel = string.Empty;

        IDictionary<int, string> expectedDic;
        IDictionary<int, string> actualDic;

        var sample = _sampleFiePath.ReadFiles(prblemLevel);
        using (var tester = new Tester(sample.InputText, sample.OutputText))
        {
            var problem = new Problem(tester.Reader, tester.Writer);
            Action method = problem.Solve;

            expectedDic = tester.ReadOutputSample();
            actualDic = tester.Execute(method);
        }

        TestTools.Judge(expectedDic, actualDic);
    }
#endif
}