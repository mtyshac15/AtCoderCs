using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC349;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    public void Solve()
    {
        var S = Console.ReadLine().Trim();

        var dic = new Dictionary<char, int>();

        for (int i = 0; i < S.Length; i++)
        {
            if (!dic.ContainsKey(S[i]))
            {
                dic.Add(S[i], 1);
            }
            else
            {
                dic[S[i]]++;
            }
        }

        var ans = true;
        for (int i = 1; i <= S.Length; i++)
        {
            var count = dic.Count(x => x.Value == i);
            if (count != 0 && count != 2)
            {
                ans = false;
                break;
            }
        }

        Console.WriteLine(ProblemB.ToYesOrNo(ans));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
