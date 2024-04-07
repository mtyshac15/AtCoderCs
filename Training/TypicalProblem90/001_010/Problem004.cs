using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Traing.Typical.Problem004;

public class Problem
{
    public static void Main(string[] args)
    {
        var problem = new Problem();
        problem.Solve();
    }

    /// <summary>
    /// Longest Circular Road
    /// </summary>
    public void Solve()
    {
        var HW = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var H = HW[0];
        var W = HW[1];

        var A = new int[H + 1, W + 1];

        for (int h = 0; h < H; h++)
        {
            var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            for (int w = 0; w < W; w++)
            {
                var a = input[w];
                A[h, w] = a;

                //行ごと、列ごとの和を保持
                A[h, W] += a;
                A[H, w] += a;
            }
        }

        var ansBuilder = new StringBuilder();
        for (int h = 0; h < H; h++)
        {
            var list = new List<int>();
            for (int w = 0; w < W; w++)
            {
                var B = A[h, W] + A[H, w] - A[h, w];
                list.Add(B);
            }
            ansBuilder.AppendLine(string.Join(" ", list));
        }

        var ans = ansBuilder.ToString();
        Console.WriteLine(ans);
    }
}
