using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC348;

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
    /// Colorful Beans
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var AC = new int[N, 2];

        for (int i = 0; i < N; i++)
        {
            var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            AC[i, 0] = input[0];
            AC[i, 1] = input[1];
        }

        var dic = new SortedDictionary<int, int>();
        dic.Add(AC[0, 1], AC[0, 0]);

        var valueArray = new List<int>();

        for (int i = 1; i < N; i++)
        {
            var A = AC[i, 0];
            var C = AC[i, 1];

            if (!dic.ContainsKey(C))
            {
                //色が異なる場合追加
                dic.Add(C, A);
            }
            else
            {
                //色が同じものがある場合、おいしさの低い方を選ぶ
                if (A < dic[C])
                {
                    dic[C] = A;
                }
            }
        }

        var ans = dic.Values.Max();
        _writer.WriteLine(ans);
    }
}
