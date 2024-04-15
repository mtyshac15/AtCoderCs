using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC321;

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
    /// Cutoff
    /// </summary>
    public void Solve()
    {
        var NX = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NX[0];
        var X = NX[1];

        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = 101;
        for (int i = 0; i <= 100; i++)
        {
            var newA = A.Append(i).ToArray();
            var currentSum = newA.Sum() - newA.Min() - newA.Max();

            if (currentSum >= X)
            {
                ans = i;
                break;
            }
        }

        if (ans > 100)
        {
            ans = -1;
        }

        _writer.WriteLine(ans);
    }
}
