﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC053;

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
    /// A to Z String 
    /// </summary>
    public void Solve()
    {
        var s = _reader.ReadLine().Trim();

        var indexA = s.IndexOf('A');
        var indexZ = new string(s.Reverse().ToArray()).IndexOf('Z');

        // zのインデックスは、s.Length - 1 - indexZ
        var ans = s.Length - indexZ - indexA;
        _writer.WriteLine(ans);
    }
}
