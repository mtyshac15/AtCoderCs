using AtCoderCs.Common.Library;
using AtCoderCs.Contest.ABC362;
using AtCoderCs.Contest.Tests;
using System.Reflection;
using Xunit;

namespace AtCoderCs.Contest.Tests.ABC362;

public class Problem
{
    private static readonly string _contestSection = $"ABC";
    private static readonly string _problemFolder = Path.Combine($"300_399", "360_369");
    private static readonly string _problemNumber = $"362";

    private SampleFiePath _sampleFiePath;

    public Problem()
    {
        _sampleFiePath = new SampleFiePath(_contestSection, _problemFolder, _problemNumber);
    }

#if true
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

    [Fact]
    public void SolveE()
    {
        var sample = _sampleFiePath.ReadFiles($"E");
        TestTools.Solve(sample, typeof(ProblemE), nameof(ProblemE.Solve));
    }

    [Fact]
    public void SolveF()
    {
        var sample = _sampleFiePath.ReadFiles($"F");
        TestTools.Solve(sample, typeof(ProblemF), nameof(ProblemF.Solve));
    }

    [Fact]
    public void SolveG()
    {
        var sample = _sampleFiePath.ReadFiles($"G");
        TestTools.Solve(sample, typeof(ProblemG), nameof(ProblemG.Solve));
    }
#endif
}