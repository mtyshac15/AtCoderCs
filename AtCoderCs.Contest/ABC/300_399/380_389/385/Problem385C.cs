using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC385.ProblemC;

public class ProblemC
{
    private Reader _reader;
    private Writer _writer;

    public ProblemC(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var N = _reader.Int();
        var H = _reader.IntArray();

        var maxCount = 1;

        for (int interval = 1; interval < N; interval++)
        {
            for (int startIndex = 0; startIndex < interval; startIndex++)
            {
                var count = 1;

                var index = startIndex;
                var nextIndex = index + interval;

                var prevH = H[index];

                // intervalの間隔で 同じ差分が連続しているかを調べる
                while (nextIndex < N)
                {
                    var nextH = H[nextIndex];
                    if (nextH == prevH)
                    {
                        count++;
                    }
                    else
                    {
                        maxCount = Math.Max(count, maxCount);
                        count = 1;
                    }

                    prevH = nextH;
                    index = nextIndex;
                    nextIndex += interval;
                }

                maxCount = Math.Max(count, maxCount);
            }
        }

        var ans = maxCount;
        _writer.WriteLine(ans);
    }
}

#region
class ProgramC
{
    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC(Console.In, Console.Out);
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
