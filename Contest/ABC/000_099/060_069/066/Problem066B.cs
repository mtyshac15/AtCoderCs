using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC066;

public class ProblemB
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemB()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemB(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// ss
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

        var ans = 0;
        for (int i = 1; i < S.Length - 1; i++)
        {
            var str = S.Substring(0, S.Length - i);
            if (str.Length % 2 == 0)
            {
                var harfLength = str.Length / 2;
                //偶文字列か判定
                var str1 = str.Substring(0, harfLength);
                var str2 = str.Substring(harfLength, harfLength);
                if (str1 == str2)
                {
                    ans = str.Length;
                    break;
                }
            }
        }

        _writer.WriteLine(ans);
    }
}
