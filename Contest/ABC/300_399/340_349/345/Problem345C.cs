using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC345;

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
    /// One Time Swap
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

        var n = S.Length;

        var dic = new Dictionary<char, int>();
        for (int i = 0; i < n; i++)
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

        //入れ替える文字のすべての選び方
        var total = (long)n * (n - 1) / 2;

        var same = 0L;
        //同じ文字を入れ替える場合
        foreach (var count in dic.Values)
        {
            same += (long)count * (count - 1) / 2;
        }

        var ans = total - same;
        if (same > 0)
        {
            // 同じ文字を入れ替える選び方が1通りでもある場合、操作後の文字列が元の文字列と同じ
            ans++;
        }

        _writer.WriteLine(ans);
    }
}
