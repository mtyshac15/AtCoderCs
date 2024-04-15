using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC322;

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
    /// 
    /// </summary>
    public void Solve()
    {
        var NM = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var S = _reader.ReadLine().Trim();
        var T = _reader.ReadLine().Trim();

        var ans = 0;

        //接頭辞
        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] != T[i])
            {
                ans = 2;
                break;
            }
        }

        //接尾辞
        for (int i = 0; i < S.Length; i++)
        {
            if (S[S.Length - 1 - i] != T[T.Length - 1 - i])
            {
                if (ans == 0)
                {
                    //接頭辞である場合
                    ans = 1;
                }
                else if (ans == 2)
                {
                    //接頭辞でも接尾辞でもない
                    ans = 3;
                }

                break;
            }
        }

        _writer.WriteLine(ans);
    }
}
