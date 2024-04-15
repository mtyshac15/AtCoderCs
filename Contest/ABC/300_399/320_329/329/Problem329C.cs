using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC329;

public class ProblemC
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Count xxx
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var S = _reader.ReadLine().Trim();

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
        _writer.WriteLine(ans);
    }
}
