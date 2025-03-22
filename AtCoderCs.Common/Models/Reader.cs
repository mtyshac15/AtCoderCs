using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Common.Models;

public class Reader
{
    private TextReader _reader;
    private int _index;
    private string[] _line;

    private char[] _cs = new char[] { ' ' };

    public Reader(TextReader reader)
    {
        _reader = reader;
        _index = 0;
        _line = new string[0];
    }

    private string NextLine()
    {
        return _reader.ReadLine().Trim();
    }

    public string Str()
    {
        if (_index < _line.Length)
        {
            return _line[_index++];
        }

        _line = StrArray();
        if (!_line.Any())
        {
            return Str();
        }

        _index = 0;
        return _line[_index++];
    }

    public int Int()
    {
        return int.Parse(Str());
    }

    public long Long()
    {
        return long.Parse(Str());
    }

    public string[] StrArray()
    {
        return NextLine().Split(_cs, StringSplitOptions.RemoveEmptyEntries);
    }

    public int[] IntArray()
    {
        return StrArray().Select(int.Parse).ToArray();
    }

    public long[] LongArray()
    {
        return StrArray().Select(long.Parse).ToArray();
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
