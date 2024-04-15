using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC315;

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
    /// The Middle Day
    /// </summary>
    public void Solve()
    {
        var M = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var D = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var middle = (D.Sum() + 1) / 2;

        var total = 0;
        var a = 1;

        //月
        for (int m = 0; m < M; m++)
        {
            if (total + D[m] < middle)
            {
                total += D[m];
            }
            else
            {
                a = m + 1;
                break;
            }
        }

        //日
        var b = middle - total;
        var ans = $"{a} {b}";
        _writer.WriteLine(ans);
    }
}
