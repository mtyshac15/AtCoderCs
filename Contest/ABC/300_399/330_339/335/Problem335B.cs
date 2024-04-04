using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC335;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        for (int x = 0; x <= N; x++)
        {
            for (int y = 0; y <= N; y++)
            {
                for (int z = 0; z <= N; z++)
                {
                    if (x + y + z <= N)
                    {
                        Console.WriteLine($"{x} {y} {z}");
                    }
                }
            }
        }
    }
}
