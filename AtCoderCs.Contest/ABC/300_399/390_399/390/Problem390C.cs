using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC390.ProblemC;

public class ProblemC
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC(Console.In, Console.Out);
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var H = _reader.Int();
        var W = _reader.Int();

        var S = new List<string>();
        for (int i = 0; i < H; i++)
        {
            S.Add(_reader.Str());
        }

        var left = W + 1;
        var right = -1;
        var top = H + 1;
        var bottom = -1;

        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                if (S[h][w] == '#')
                {
                    left = Math.Min(w, left);
                    top = Math.Min(h, top);
                }
            }
        }

        for (int h = H - 1; h >= 0; h--)
        {
            for (int w = W - 1; w >= 0; w--)
            {
                if (S[h][w] == '#')
                {
                    right = Math.Max(w, right);
                    bottom = Math.Max(h, bottom);
                }
            }
        }

        var isRectangle = true;

        for (int h = top; h <= bottom; h++)
        {
            for (int w = left; w <= right; w++)
            {
                if (S[h][w] == '.')
                {
                    isRectangle = false;
                    break;
                }
            }

            if (!isRectangle)
            {
                break;
            }
        }

        var ans = isRectangle;
        _writer.WriteYesOrNo(ans);
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
