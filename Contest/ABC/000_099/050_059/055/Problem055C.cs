using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC055;

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
    /// X: Yet Another Die Game
    /// </summary>
    public void Solve()
    {
        var NM = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        //cをすべて使用した場合に必要なSの残り数
        var sub = M / 2 - N;

        var ans = 0L;
        if (sub < 0)
        {
            //S が余る場合
            ans = M / 2;
        }
        else
        {
            //cを組み合わせる場合
            ans = N + sub / 2;
        }

        _writer.WriteLine(ans);
    }
}
