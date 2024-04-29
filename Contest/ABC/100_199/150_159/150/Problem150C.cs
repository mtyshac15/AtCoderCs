using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC150;

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
    /// Count Order
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var P = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var Q = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var factorial = new int[N + 1];
        factorial[0] = 1;
        for (int i = 1; i < N + 1; i++)
        {
            factorial[i] = i * factorial[i - 1];
        }

        var a = 1;
        var list = Enumerable.Range(1, N).ToList();
        for (int i = 0; i < N; i++)
        {
            var index = list.IndexOf(P[i]);
            var num = factorial[N - i - 1];

            a += index * num;
            list.Remove(P[i]);
        }

        var b = 1;
        list = Enumerable.Range(1, N).ToList();
        for (int i = 0; i < N; i++)
        {
            var index = list.IndexOf(Q[i]);
            var num = factorial[N - i - 1];

            b += index * num;
            list.Remove(Q[i]);
        }

        var ans = Math.Abs(a - b);
        _writer.WriteLine(ans);
    }
}
