using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC340;

public class ProblemC
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    private IDictionary<long, long> _memo;

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
    /// Divide and Divide
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray()[0];

        _memo = new Dictionary<long, long>();

        var ans = this.Calc(N);
        _writer.WriteLine(ans);
    }

    public long Calc(long N)
    {
        if (N == 1)
        {
            return 0;
        }

        if (_memo.ContainsKey(N))
        {
            return _memo[N];
        }

        var left = N / 2;
        var right = N - left;

        var sum = N + this.Calc(left) + this.Calc(right);

        //メモ化
        _memo.Add(N, sum);

        return sum;
    }
}
