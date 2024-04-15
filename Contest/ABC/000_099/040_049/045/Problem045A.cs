﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC045;

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
    /// 
    /// </summary>
    public void Solve()
    {
        var a = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var b = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var h = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var ans = (a + b) * h / 2;
        _writer.WriteLine(ans);
    }
}