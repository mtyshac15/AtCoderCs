﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC054;

public class ProblemA
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA()
    {
    }

    public ProblemA(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// One Card Poker
    /// </summary>
    public void Solve()
    {
        var AB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = AB[0];
        var B = AB[1];

        if (A == 1)
        {
            A = 14;
        }

        if (B == 1)
        {
            B = 14;
        }

        var ans = string.Empty;
        if (A == B)
        {
            ans = "Draw";
        }
        else if (A > B)
        {
            ans = "Alice";
        }
        else if (A < B)
        {
            ans = "Bob";
        }

        _writer.WriteLine(ans);
    }
}
