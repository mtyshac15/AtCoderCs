using AtCoderCs.Common.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC311;

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
    /// First ABC
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var S = _reader.ReadLine().Trim();

        var set = new HashSet<int>();
        var ans = 1;

        for (int i = 0; i < N; i++)
        {
            set.Add(S[i]);
            if (set.Count == 3)
            {
                ans = i + 1;
                break;
            }
        }

        _writer.WriteLine(ans);
    }
}
