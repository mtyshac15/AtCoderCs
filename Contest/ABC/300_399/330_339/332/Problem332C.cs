﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC332;

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

        var S = _reader.ReadLine().Trim();
        var newS = S.ToCharArray().Append('0');

        var plain = 0;
        var logo = 0;

        var ans = 0;
        foreach (var c in newS)
        {
            switch (c)
            {
                case '0':
                    //必要枚数
                    var count = Math.Max(plain + logo - M, logo);
                    ans = Math.Max(count, ans);

                    plain = 0;
                    logo = 0;
                    break;

                case '1':
                    plain++;
                    break;

                case '2':
                    logo++;
                    break;
            }
        }

        _writer.WriteLine(ans);
    }
}
