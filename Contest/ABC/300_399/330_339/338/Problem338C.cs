﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC338;

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
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var Q = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var B = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var maxA = int.MaxValue;
        for (int i = 0; i < N; i++)
        {
            if (A[i] != 0)
            {
                maxA = Math.Min(Q[i] / A[i], maxA);
            }
        }

        var total = 0;

        //Aを固定し、残りの材料でBを作る
        for (int countA = 0; countA <= maxA; countA++)
        {
            var countB = int.MaxValue;
            for (int j = 0; j < N; j++)
            {
                if (B[j] != 0)
                {
                    var remainder = Q[j] - A[j] * countA;
                    countB = Math.Min(remainder / B[j], countB);
                }
            }

            total = Math.Max(total, countA + countB);
        }

        var ans = total;
        _writer.WriteLine(ans);
    }
}
