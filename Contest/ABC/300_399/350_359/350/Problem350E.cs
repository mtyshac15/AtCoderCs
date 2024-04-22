﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC350;

public class ProblemE
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemE();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemE()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemE(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {

    }
}
