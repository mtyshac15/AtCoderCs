using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC314;

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
    /// Roulette
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var C = new int[N];
        var A = new int[N][];

        for (int i = 0; i < N; i++)
        {
            C[i] = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
            A[i] = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        }

        var X = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var iList = new List<int>();
        for (int i = 0; i < N; i++)
        {
            if (A[i].Contains(X))
            {
                iList.Add(i);
            }
        }

        var minC = 37;
        foreach (int i in iList)
        {
            minC = Math.Min(C[i], minC);
        }

        var B = iList.Where(i => C[i] == minC).ToArray();
        var K = B.Length;

        var ansBuilder = new StringBuilder();
        ansBuilder.AppendLine(K.ToString());
        ansBuilder.AppendLine(string.Join(" ", B.Select(i => i + 1)));

        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
