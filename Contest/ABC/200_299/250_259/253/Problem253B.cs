using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC253;

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
    /// Distance Between Tokens
    /// </summary>
    public void Solve()
    {
        var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var H = input[0];
        var W = input[1];

        var S = new string[H];
        for (int i = 0; i < H; i++)
        {
            S[i] = _reader.ReadLine().Trim();
        }

        var piece = new int[2, 2];

        var index = 0;
        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                if (S[h][w] == 'o')
                {
                    piece[index, 0] = h;
                    piece[index, 1] = w;
                    index++;
                }
            }
        }

        var dH = Math.Abs(piece[0, 0] - piece[1, 0]);
        var dW = Math.Abs(piece[0, 1] - piece[1, 1]);

        var ans = dH + dW;
        _writer.WriteLine(ans);
    }
}
