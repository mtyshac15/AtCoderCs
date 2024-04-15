using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC144;

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
    /// Walk on Multiplication Table
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray()[0];

        var ans = long.MaxValue;

        //√Nまで探索
        for (long i = 1L; i * i <= N; i++)
        {
            // i*j=N が成り立つ場合のみ有効
            var j = N / i;
            if (i * j == N)
            {
                var d = (i - 1) + (j - 1);
                ans = Math.Min(d, ans);
            }
        }

        _writer.WriteLine(ans);
    }
}
