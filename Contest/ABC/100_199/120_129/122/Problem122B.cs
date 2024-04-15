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
        for (int count = 1; count < S.Length + 1; count++)
        {
            for (int startIndex = 0; startIndex < S.Length; startIndex++)
            {
                if (startIndex + count <= S.Length)
                {
                    // Sから count の文字数分、文字列を抽出
                    var sArray = new char[count];
                    for (int i = 0; i < count; i++)
                    {
                        sArray[i] = S[startIndex + i];
                    }

                    //部分文字列かどうか判定
                    var isPartial = true;
                    foreach (char c in sArray)
                    {
                        if (!acgt.Contains(c))
                        {
                            isPartial = false;
                            break;
                        }
                    }

                    if (isPartial)
                    {
                        ans = Math.Max(sArray.Length, ans);
                    }
                }
            }
        }

        _writer.WriteLine(ans);
    }
}
