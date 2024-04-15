using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace AtCoderCs.Contest.ABC318;

public class ProblemA
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA()
    {
    }

    public ProblemA(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Full Moon
    /// </summary>
    public void Solve()
    {
        var NMP = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NMP[0];
        var M = NMP[1];
        var P = NMP[2];

        var ans = 0;
        if (N - M >= 0)
        {
            ans++;
        }

        ans += (N - M) / P;
        _writer.WriteLine(ans);
    }
}
