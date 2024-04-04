using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC212;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Alloy
    /// </summary>
    public void Solve()
    {
        var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = input[0];
        var B = input[1];

        if (A > 0 && B == 0)
        {
            Console.WriteLine("Gold");
        }
        else if (A == 0 && B > 0)
        {
            Console.WriteLine("Silver");

        }
        else
        {
            Console.WriteLine("Alloy");
        }
    }
}
