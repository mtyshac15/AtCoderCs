using AtCoderCs.Common.Library;
using AtCoderCs.Contest.ABC058;
using AtCoderCs.Contest.Tests;
using System.Reflection;
using Xunit;

namespace AtCoderCs.Contest.Tests.ABC058;

public class Problem
{
    private static readonly string _contestSection = $"ABC";
    private static readonly string _problemFolder = Path.Combine($"000_099", "050_059");
    private static readonly string _problemNumber = $"058";

    private SampleFiePath _sampleFiePath;

    public Problem()
    {
        _sampleFiePath = new SampleFiePath(_contestSection, _problemFolder, _problemNumber);
    }

#if false
    [Fact]
    public void SolveA()
    {
        var sample = _sampleFiePath.ReadFiles($"A");
        TestTools.Solve(sample, typeof(ProblemA), nameof(ProblemA.Solve));
    }

    [Fact]
    public void SolveB()
    {
        var sample = _sampleFiePath.ReadFiles($"B");
        TestTools.Solve(sample, typeof(ProblemB), nameof(ProblemB.Solve));
    }

    [Fact]
    public void SolveC()
    {
        var sample = _sampleFiePath.ReadFiles($"C");
        TestTools.Solve(sample, typeof(ProblemC), nameof(ProblemC.Solve));
    }

    [Fact]
    public void SolveD()
    {
        var sample = _sampleFiePath.ReadFiles($"D");
        TestTools.Solve(sample, typeof(ProblemD), nameof(ProblemD.Solve));
    }
#endif
}