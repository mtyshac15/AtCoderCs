﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC391.ProblemB;

public class ProblemB
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB(Console.In, Console.Out);
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemB(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var N = _reader.Int();
        var M = _reader.Int();

        var S = _reader.Grid(N, N);
        var T = _reader.Grid(M, M);

        var a = 1;
        var b = 1;

        var isMatch = true;

        for (int si = 0; si < N - M + 1; si++)
        {
            for (int sj = 0; sj < N - M + 1; sj++)
            {
                isMatch = true;

                for (int ti = 0; ti < M; ti++)
                {
                    for (int tj = 0; tj < M; tj++)
                    {
                        if (S[si + ti, sj + tj] != T[ti, tj])
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    if (!isMatch)
                    {
                        break;
                    }
                }

                if (isMatch)
                {
                    a = si + 1;
                    b = sj + 1;
                }
            }

            if (isMatch)
            {
                break;
            }
        }

        var ans = $"{a} {b}";
        _writer.WriteLine(ans);
    }
}

#region
class Reader
{
    private TextReader _reader;
    private int _index;
    private string[] _line;

    private char[] _cs = new char[] { ' ' };

    public Reader(TextReader reader)
    {
        _reader = reader;
        _index = 0;
        _line = Array.Empty<string>();
    }

    private string NextLine()
    {
        var line = _reader.ReadLine() ?? string.Empty;
        return line.Trim();
    }

    public string Str()
    {
        if (_index < _line.Length)
        {
            return _line[_index++];
        }

        _line = this.StrArray();
        if (!_line.Any())
        {
            return this.Str();
        }

        _index = 0;
        return _line[_index++];
    }

    public int Int()
    {
        return int.Parse(this.Str());
    }

    public long Long()
    {
        return long.Parse(this.Str());
    }

    public string[] StrArray()
    {
        return this.NextLine().Split(_cs, StringSplitOptions.RemoveEmptyEntries);
    }

    public int[] IntArray()
    {
        return this.StrArray().Select(int.Parse).ToArray();
    }

    public long[] LongArray()
    {
        return this.StrArray().Select(long.Parse).ToArray();
    }

    public char[,] Grid(int H, int W)
    {
        var grid = new char[H, W];
        for (int h = 0; h < H; h++)
        {
            var line = Str();
            for (int w = 0; w < W; w++)
            {
                grid[h, w] = line[w];
            }
        }
        return grid;
    }
}

class Writer
{
    private TextWriter _writer;

    public Writer(TextWriter writer)
    {
        _writer = writer;
    }

    public void WriteLine(object? value = null)
    {
        _writer.WriteLine(value);
    }

    public void WriteYesOrNo(bool value)
    {
        this.WriteLine(Writer.ToYesOrNo(value));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
#endregion
