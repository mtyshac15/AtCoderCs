using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC122;

public class ProblemB
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemB()
    {
    }

    public ProblemB(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// ATCoder
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

        var acgt = new char[]
        {
            'A','C','G','T'
        };

        var ans = 0;

        // 1文字からN文字列分調べる
        for (int count = 1; count <= S.Length; count++)
        {
            for (int startIndex = 0; startIndex < S.Length; startIndex++)
            {
                // Sから count の文字数分、文字列を抽出
                var length = Math.Min(count, S.Length - startIndex);
                var str = S.Substring(startIndex, length);

                //部分文字列かどうか判定
                var isPartial = str.All(c => acgt.Contains(c));
                if (isPartial)
                {
                    ans = Math.Max(str.Length, ans);
                }
            }
        }

        _writer.WriteLine(ans);
    }
}
