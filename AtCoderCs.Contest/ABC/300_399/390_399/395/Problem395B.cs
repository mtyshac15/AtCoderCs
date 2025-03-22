using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC395.ProblemB;

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

        var grid = new char[N, N];

        var max = (N + 1) / 2;
        for (int layer = 0; layer < max; layer++)
        {
            var cell = layer % 2 == 0 ? '#' : '.';

            for (int i = layer; i < N - layer; i++)
            {
                for (int j = layer; j < N - layer; j++)
                {
                    grid[i, j] = cell;
                }
            }
        }

        _writer.WriteGrid(grid);
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

    public void WriteGrid<T>(T[,] grid)
    {
        var row = grid.GetLength(0);
        var col = grid.GetLength(1);

        var list = new List<string>();
        var line = new T[col];

        for (int h = 0; h < row; h++)
        {
            for (int w = 0; w < col; w++)
            {
                line[w] = grid[h, w];
            }

            list.Add(string.Concat(line));
        }

        this.WriteLine(string.Join(Environment.NewLine, list));
    }
}
#endregion