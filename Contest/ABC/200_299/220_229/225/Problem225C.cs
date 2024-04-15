using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC225;

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
    /// Calendar Validator
    /// </summary>
    public void Solve()
    {
        var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = input[0];
        var M = input[1];

        var B = new int[N, M];

        for (var i = 0; i < N; i++)
        {
            var tmp = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

            for (var j = 0; j < M; j++)
            {
                B[i, j] = tmp[j];
            }
        }

        //1行目を判定
        for (var col = 0; col < M; col++)
        {
            var num = B[0, col] % 7;

            //7で割った余りが0の数が、右端でない場合はNo
            if (num == 0
                && col != M - 1)
            {
                _writer.WriteLine(IOLibrary.ToYesOrNo(false));
                return;
            }
        }

        //行方向 公差1の等差数列
        for (int row = 0; row < N; row++)
        {
            var num = B[row, 0];
            for (int col = 1; col < M; col++)
            {
                var sub = B[row, col] - num;
                if (sub != 1)
                {
                    _writer.WriteLine(IOLibrary.ToYesOrNo(false));
                    return;
                }

                num = B[row, col];
            }
        }

        //列方向 公差7の等差数列
        for (int col = 0; col < M; col++)
        {
            var num = B[0, col];
            for (int row = 1; row < N; row++)
            {
                var sub = B[row, col] - num;
                if (sub != 7)
                {
                    _writer.WriteLine(IOLibrary.ToYesOrNo(false));
                    return;
                }

                num = B[row, col];
            }
        }

        _writer.WriteLine(IOLibrary.ToYesOrNo(true));
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
