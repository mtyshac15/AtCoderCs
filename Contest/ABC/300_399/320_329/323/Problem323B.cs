﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC323;

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
    /// Round-Robin Tournament
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var S = new string[N];
        for (int i = 0; i < N; i++)
        {
            S[i] = _reader.ReadLine().Trim();
        }

        //勝敗を集計
        var win = new int[N];
        for (int i = 0; i < N; i++)
        {
            win[i] = S[i].Count(x => x == 'o');
        }

        var array = win.Select((x, i) => (x, i)).OrderByDescending(x => x.x);

        var ans = string.Join(" ", array.Select(x => x.i + 1));
        _writer.WriteLine(ans);
    }
}
