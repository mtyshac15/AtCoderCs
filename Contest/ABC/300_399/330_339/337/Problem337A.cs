using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Contest.ABC337;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Scoreboard
    /// </summary>
    public void Solve()
    {
        var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = input[0];

        var sumX = 0;
        var sumY = 0;

        for (var i = 0; i < N; i++)
        {
            var XY = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            sumX += XY[0];
            sumY += XY[1];
        }

        if (sumX > sumY)
        {
            Console.WriteLine("Takahashi");
            return;
        }
        else if (sumX < sumY)
        {
            Console.WriteLine("Aoki");
            return;
        }

        Console.WriteLine("Draw");
    }
}
