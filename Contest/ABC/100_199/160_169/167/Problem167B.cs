using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC167;

public class ProblemB
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemB()
    {
    }

    public ProblemB(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Easy Linear Programming
    /// </summary>
    public void Solve()
    {
        var ABCK = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = ABCK[0];
        var B = ABCK[1];
        var C = ABCK[2];
        var K = ABCK[3];

        var countA = Math.Min(A, K);
        var countB = Math.Min(B, K - countA);
        var countC = Math.Min(C, K - countA - countB);

        var ans = countA - countC;
        _writer.WriteLine(ans);
    }
}
