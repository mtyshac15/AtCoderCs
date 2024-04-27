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

        var A = new int[N];
        var C = new int[N];
        for (int i = 0; i < N; i++)
        {
            var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            A[i] = input[0];
            C[i] = input[1];
        }

        var dic = new Dictionary<int, int>();
        dic.Add(C[0], A[0]);

        for (int i = 1; i < N; i++)
        {
            if (!dic.ContainsKey(C[i]))
            {
                //色が異なる場合追加
                dic.Add(C[i], A[i]);
            }
            else
            {
                //色が同じものがある場合、おいしさの低い方を選ぶ
                dic[C[i]] = Math.Min(A[i], dic[C[i]]);
            }
        }

        var ans = dic.Values.Max();
        _writer.WriteLine(ans);
    }
}
