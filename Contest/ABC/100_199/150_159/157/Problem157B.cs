using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC157;

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
    /// Bingo
    /// </summary>
    public void Solve()
    {
        var A = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

            for (int j = 0; j < 3; j++)
            {
                A[i, j] = input[j];
            }
        }

        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var b = new int[N];
        for (int i = 0; i < N; i++)
        {
            b[i] = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        }

        var ans = false;

        //横
        for (int i = 0; i < 3; i++)
        {
            var isBingo = true;
            for (int j = 0; j < 3; j++)
            {
                if (!b.Contains(A[i, j]))
                {
                    isBingo = false;
                    break;
                }
            }

            ans |= isBingo;
        }

        //縦
        for (int i = 0; i < 3; i++)
        {
            var isBingo = true;
            for (int j = 0; j < 3; j++)
            {
                if (!b.Contains(A[j, i]))
                {
                    isBingo = false;
                    break;
                }
            }

            ans |= isBingo;
        }

        //斜め
        {
            var isBingo = true;
            for (int i = 0; i < 3; i++)
            {
                if (!b.Contains(A[i, i]))
                {
                    isBingo = false;
                    break;
                }
            }

            ans |= isBingo;
        }

        {
            var isBingo = true;
            for (int i = 0; i < 3; i++)
            {
                if (!b.Contains(A[i, 2 - i]))
                {
                    isBingo = false;
                    break;
                }
            }

            ans |= isBingo;
        }

        _writer.WriteLine(IOLibrary.ToYesOrNo(ans));
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
