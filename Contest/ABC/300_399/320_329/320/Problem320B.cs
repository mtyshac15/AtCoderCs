using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC320;

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

    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

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

        _writer.WriteLine(ans);
    }
}
