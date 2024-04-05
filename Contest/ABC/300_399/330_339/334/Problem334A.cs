﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC334;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Christmas Present
    /// </summary>
    public void Solve()
    {
        var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var B = input[0];
        var G = input[1];

        var ans = "Bat";
        if (B < G)
        {
            ans = "Glove";
        }
        Console.WriteLine(ans);
    }
}
