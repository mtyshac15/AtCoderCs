using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC200.ProblemD;

public class ProblemD
{
    private Reader _reader;
    private Writer _writer;

    public ProblemD(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var N = _reader.Int();
        var A = _reader.IntArray();

        var BDic = new Dictionary<int, IList<IList<int>>>();
        var d = Math.Min(N, 8);
        for (int i = 0; i < 1 << d; i++)
        {
            var sum = 0;
            var list = new List<int>();
            for (int bit = 0; bit < d; bit++)
            {
                if (((i >> bit) & 1) == 1)
                {
                    sum += A[bit];
                    sum %= 200;

                    list.Add(bit + 1);
                }
            }

            if (list.Any())
            {
                if (!BDic.ContainsKey(sum))
                {
                    BDic.Add(sum, new List<IList<int>>() { list });
                }
                else
                {
                    BDic[sum].Add(list);
                }
            }
        }

        if (BDic.Values.Any(x => x.Count >= 2))
        {
            var lists = BDic.Values.First(x => x.Count >= 2);
            var B = lists[0];
            var x = B.Count;

            var C = lists[1];
            var y = C.Count;

            _writer.WriteYesOrNo(true);
            _writer.WriteLine($"{x} {string.Join(" ", B)}");
            _writer.WriteLine($"{y} {string.Join(" ", C)}");
        }
        else
        {
            _writer.WriteYesOrNo(false);
        }
    }
}

#region
class ProgramD
{
    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemD(Console.In, Console.Out);
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
