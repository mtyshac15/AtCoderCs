using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC116;

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
    /// Collatz Problem
    /// </summary>
    public void Solve()
    {
        var s = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var a = s;
        var ans = 1;

        var set = new HashSet<int>();

        while (set.Add(a))
        {
            if (a % 2 == 0)
            {
                a = a / 2;
            }
            else
            {
                a = 3 * a + 1;
            }

            ans++;
        }

        _writer.WriteLine(ans);
    }
}
