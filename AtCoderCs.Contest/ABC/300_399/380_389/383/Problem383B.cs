using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC383.ProblemB;

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
        var H = _reader.Int();
        var W = _reader.Int();
        var D = _reader.Int();

        var S = _reader.Grid(H, W);

        var maxCount = 0;

        for (int h1 = 0; h1 < H; h1++)
        {
            for (int w1 = 0; w1 < W; w1++)
            {
                for (int h2 = 0; h2 < H; h2++)
                {
                    for (int w2 = 0; w2 < W; w2++)
                    {
                        var same = h1 == h2 && w1 == w2;

                        if (!same
                            && S[h1, w1] == '.'
                            && S[h2, w2] == '.')
                        {
                            var count = 0;

                            // 各マスから加湿器までの距離を計算
                            for (int h = 0; h < H; h++)
                            {
                                for (int w = 0; w < W; w++)
                                {
                                    if (S[h, w] == '.')
                                    {
                                        var d1 = Math.Abs(h - h1) + Math.Abs(w - w1);
                                        var d2 = Math.Abs(h - h2) + Math.Abs(w - w2);

                                        if (d1 <= D || d2 <= D)
                                        {
                                            count++;
                                        }
                                    }
                                }
                            }

                            maxCount = Math.Max(count, maxCount);
                        }
                    }
                }
            }
        }

        var ans = maxCount;
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