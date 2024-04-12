using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC320;

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

        var ans = 1;
        for (int count = 2; count <= S.Length; count++)
        {
            for (int start = 0; start < S.Length - count + 1; start++)
            {
                var isPalindrome = true;
                for (int i = 0; i <= count / 2; i++)
                {
                    var index = start + i;

                    if (S[index] != S[start + count - 1 - i])
                    {
                        isPalindrome = false;
                        break;
                    }
                }

                if (isPalindrome)
                {
                    ans = Math.Max(count, ans);
                }
            }
        }

        Console.WriteLine(ans);
    }
}
