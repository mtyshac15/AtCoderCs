using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC157;

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
    /// Guess The Number
    /// </summary>
    public void Solve()
    {
        var NM = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var s = new int[M];
        var c = new int[M];
        for (int i = 0; i < M; i++)
        {
            var sc = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            s[i] = sc[0];
            c[i] = sc[1];
        }

        var ans = -1;
        for (int i = 0; i < 999; i++)
        {
            //ちょうどN桁
            var numStr = i.ToString();
            if (numStr.Length == N)
            {
                var isMatch = true;
                for (int j = 0; j < M; j++)
                {
                    var num = int.Parse(numStr[s[j] - 1].ToString());
                    if (num != c[j])
                    {
                        isMatch = false;
                        break;
                    }
                }

                if (isMatch)
                {
                    ans = i;
                    break;
                }
            }
        }

        _writer.WriteLine(ans);
    }
}
