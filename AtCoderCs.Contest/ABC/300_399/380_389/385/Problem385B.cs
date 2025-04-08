using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC385.ProblemB;

public class ProblemB
{
    private Reader _reader;
    private Writer _writer;

    public ProblemB(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var H = _reader.Int();
        var W = _reader.Int();
        var X = _reader.Int();
        var Y = _reader.Int();
        var S = _reader.Grid(H, W);
        var T = _reader.Str();

        var seen = new bool[H, W];

        var c = 0;
        var x = X - 1;
        var y = Y - 1;

        Func<int, int, bool> canMove = (h, w) =>
        {
            return h >= 0 && h < H
            && w >= 0 && w < W
            && S[h, w] != '#';
        };

        Action<int, int> visit = (h, w) =>
        {
            if (S[h, w] == '@'
            && !seen[h, w])
            {
                c++;
                seen[h, w] = true;
            }
        };

        for (int i = 0; i < T.Length; i++)
        {
            switch (T[i])
            {
                case 'U':
                    {
                        if (canMove(x - 1, y))
                        {
                            x--;
                        }
                    }
                    break;

                case 'D':
                    {
                        if (canMove(x + 1, y))
                        {
                            x++;
                        }
                    }
                    break;

                case 'L':
                    {
                        if (canMove(x, y - 1))
                        {
                            y--;
                        }
                    }
                    break;

                case 'R':
                    {
                        if (canMove(x, y + 1))
                        {
                            y++;
                        }
                    }
                    break;
            }

            visit(x, y);
        }

        var ans = $"{x + 1} {y + 1} {c}";
        _writer.WriteLine(ans);
    }
}

#region
class ProgramB
{
    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB(Console.In, Console.Out);
        problem.Solve();
        Console.Out.Flush();
    }
}

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