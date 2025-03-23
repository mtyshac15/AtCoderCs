using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABCLike.ZONE2021.ProblemB;

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
        var N = _reader.Int();
        var D = _reader.Int();
        var H = _reader.Int();

        var dic = new Dictionary<int, (int d, int h)>();
        for (int i = 0; i < N; i++)
        {
            var d = _reader.Int();
            var h = _reader.Int();
            dic[i] = (d, h);
        }

        var minA = dic.Min(keyValue => (decimal)(H - keyValue.Value.h) / (D - keyValue.Value.d));
        var ans = Math.Max(minA * (-D) + H, 0);
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
