using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC061;

public class ProblemB
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemB()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemB(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Counting Roads
    /// </summary>
    public void Solve()
    {
        var NM = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var a = new int[M];
        var b = new int[M];

        for (int i = 0; i < M; i++)
        {
            var ab = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            a[i] = ab[0];
            b[i] = ab[1];
        }

        var dictionary = new Dictionary<int, int>();
        for (int i = 1; i <= N; i++)
        {
            dictionary.Add(i, 0);
        }

        for (int i = 0; i < M; i++)
        {
            dictionary[a[i]]++;
            dictionary[b[i]]++;
        }

        var ansBuilder = new StringBuilder();
        for (int i = 1; i <= N; i++)
        {
            var count = dictionary[i];
            ansBuilder.AppendLine($"{count}");
        }

        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
