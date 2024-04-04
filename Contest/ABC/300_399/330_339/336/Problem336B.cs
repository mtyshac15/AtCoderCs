using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Contest.ABC336;

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

        var ans = 0;
        var tmpN = N;

        while (true)
        {
            var remainder = tmpN % 2;
            tmpN = tmpN / 2;

            if (remainder == 0)
            {
                ans++;
            }

            if (remainder == 1 || tmpN == 0)
            {
                break;
            }
        }

        Console.WriteLine(ans);
    }
}
