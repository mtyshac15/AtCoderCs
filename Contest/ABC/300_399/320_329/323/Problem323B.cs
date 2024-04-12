using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC323;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// Round-Robin Tournament
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var S = new string[N];
        for (int i = 0; i < N; i++)
        {
            S[i] = Console.ReadLine().Trim();
        }

        var array = new int[N];
        for (int i = 0; i < N; i++)
        {
            for (int j = i + 1; j < N; j++)
            {
                if (S[i][j] == 'o')
                {
                    array[i]++;
                }
                else
                {
                    array[j]++;
                }
            }
        }

        var list = new List<int>();

        for (int win = N; win >= 0; win--)
        {
            for (int i = 0; i < N; i++)
            {
                if (array[i] == win)
                {
                    list.Add(i + 1);
                }
            }
        }

        var ans = string.Join(" ", list);
        Console.WriteLine(ans);
    }
}
