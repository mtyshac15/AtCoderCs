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

    public string Next()
    {
        if (_index < _line.Length)
        {
            return _line[_index++];
        }

        _line = NextArray();
        if (!_line.Any())
        {
            return Next();
        }

        _index = 0;
        return _line[_index++];
    }

    public int NextInt()
    {
        return int.Parse(Next());
    }

    public long NextLong()
    {
        return long.Parse(Next());
    }

    public string[] NextArray()
    {
        return NextLine().Split(_cs, StringSplitOptions.RemoveEmptyEntries);
    }

    public int[] NextIntArray()
    {
        return NextArray().Select(int.Parse).ToArray();
    }
}
