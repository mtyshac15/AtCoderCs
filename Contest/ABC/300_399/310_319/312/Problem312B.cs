using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC312;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// TaK Code
    /// </summary>
    public void Solve()
    {
        var NM = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var S = new string[N];
        for (int i = 0; i < N; i++)
        {
            S[i] = Console.ReadLine().Trim();
        }

        var ansBuilder = new StringBuilder();

        for (int i = 0; i < N - 8; i++)
        {
            for (int j = 0; j < M - 8; j++)
            {
                if (this.IsTakCode(S, i, j))
                {
                    ansBuilder.AppendLine($"{i + 1} {j + 1}");
                }
            }
        }

        var ans = ansBuilder.ToString();
        Console.WriteLine(ans);
    }

    private bool IsTakCode(string[] S, int i, int j)
    {
        for (int dx = 0; dx < 3; dx++)
        {
            for (int dy = 0; dy < 3; dy++)
            {
                //左上 黒
                if (S[i + dx][j + dy] != '#')
                {
                    return false;
                }

                //右下 黒
                if (S[i + 8 - dx][j + 8 - dy] != '#')
                {
                    return false;
                }
            }

            //白
            if (S[i + dx][j + 3] != '.')
            {
                return false;
            }

            if (S[i + 8 - dx][j + 5] != '.')
            {
                return false;
            }
        }

        for (int dy = 0; dy < 4; dy++)
        {
            //左上 白
            if (S[i + 3][j + dy] != '.')
            {
                return false;
            }

            //右下 白
            if (S[i + 5][j + 8 - dy] != '.')
            {
                return false;
            }
        }

        return true;
    }
}
