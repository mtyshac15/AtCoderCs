using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC186;

public class ProblemD
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemD();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemD()
    {
    }

    public ProblemD(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        Array.Sort(A);
        var sortedA = A.Reverse().ToArray();

        var ans = 0L;
        var count = N / 2;
        for (int i = 0; i < count; i++)
        {
            var a = N - 2 * i - 1;
            var subA = sortedA[i] - sortedA[N - i - 1];
            ans += (long)a * subA;
        }

        _writer.WriteLine(ans);
    }
}
