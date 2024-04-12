using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC329;

public class ProblemC
{
    public static void Main(string[] args)
    {
        var problem = new ProblemC();
        problem.Solve();
    }

    /// <summary>
    /// Count xxx
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var S = Console.ReadLine().Trim();

        var list = new List<string>();

        var prevS = S[0];
        var charCount = 1;

        var strDic = new Dictionary<char, int>()
        {
            { prevS, charCount },
        };

        for (int i = 1; i < S.Length; i++)
        {
            var currentS = S[i];
            if (currentS == prevS)
            {
                charCount++;
            }
            else
            {
                if (!strDic.ContainsKey(prevS))
                {
                    strDic.Add(prevS, charCount);
                }
                else
                {
                    var prevCount = strDic[prevS];
                    strDic[prevS] = Math.Max(charCount, prevCount);
                }

                charCount = 1;
            }

            prevS = currentS;
        }

        //末尾に同じ文字が連続していた場合に追加
        if (!strDic.ContainsKey(prevS))
        {
            strDic.Add(prevS, charCount);
        }
        else
        {
            var prevCount = strDic[prevS];
            strDic[prevS] = Math.Max(charCount, prevCount);
        }

        var ans = strDic.Values.Sum();
        Console.WriteLine(ans);
    }
}
