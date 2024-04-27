using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC346;

public class ProblemC
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Ideal Holidays
    /// </summary>
    public void Solve()
    {
        var NK = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NK[0];
        var K = NK[1];

        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var sumK = (1 + (long)K) * K / 2;

        var setA = new HashSet<long>();
        for (int i = 0; i < N; i++)
        {
            if (A[i] >= 1
                && A[i] <= K)
            {
                setA.Add(A[i]);
            }
        }

        var ans = sumK - setA.Sum();
        _writer.WriteLine(ans);
    }
}
