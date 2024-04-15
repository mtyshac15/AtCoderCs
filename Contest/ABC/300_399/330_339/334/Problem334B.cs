using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC334;

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
    /// Christmas Trees
    /// </summary>
    public void Solve()
    {
        var input = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray();
        var A = input[0];
        var M = input[1];
        var L = input[2];
        var R = input[3];

        var decR = (R - A) / (decimal)M;
        var decL = (L - A) / (decimal)M;

        var longL = (long)decL;
        var longR = (long)decR;

        var ans = 0L;
        if (decL >= 0 && decR >= 0)
        {
            if (decL == longL)
            {
                ans = longR - longL + 1;
            }
            else
            {
                ans = longR - longL;
            }
        }
        else if (decL < 0 && decR >= 0)
        {
            ans = longR - longL + 1;
        }
        else
        {
            if (decR == longR)
            {
                ans = longR - longL + 1;
            }
            else
            {
                ans = longR - longL;
            }
        }

        _writer.WriteLine(ans);
    }
}
