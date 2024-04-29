using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC117;

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

    public void Solve()
    {
        var NM = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var X = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        Array.Sort(X);

        //隣りあった座標の差分を取る
        var sub = new int[M];
        for (int i = 0; i < M - 1; i++)
        {
            sub[i + 1] = X[i + 1] - X[i];
        }

        Array.Sort(sub);

        //各座標の差のうち、大きい方から N-1 個の要素を除き、残った差の和をとる
        var count = Math.Max(M - N + 1, 0);
        var ans = sub.Take(count).Sum();
        _writer.WriteLine(ans);
    }
}
