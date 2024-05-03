using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC093;

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
    /// Small and Large Integers
    /// </summary>
    public void Solve()
    {
        var ABK = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = ABK[0];
        var B = ABK[1];
        var K = ABK[2];

        var set = new SortedSet<int>();

        for (int i = 0; i < K; i++)
        {
            if (A + i <= B)
            {
                set.Add(A + i);
            }

            if (B - i >= A)
            {
                set.Add(B - i);
            }
        }

        var ans = string.Join(Environment.NewLine, set);
        _writer.WriteLine(ans);
    }
}
