using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC380.ProblemC;

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
        var N = _reader.Int();
        var K = _reader.Int();
        var S = _reader.Str();

        var S0 = string.Concat(S, "0");

        // K-1番目
        var jStartIndex = -1;
        var jEndtIndex = -1;

        // K番目
        var kStartIndex = -1;
        var kEndtIndex = -1;

        var isOne = false;

        var count = 0;
        for (int i = 0; i < S0.Length; i++)
        {
            if (!isOne)
            {
                if (S0[i] == '1')
                {
                    isOne = true;

                    count++;
                    if (count == K - 1)
                    {
                        jStartIndex = i;
                    }
                    else if (count == K)
                    {
                        kStartIndex = i;
                    }
                }
            }
            else
            {
                if (S0[i] == '0')
                {
                    isOne = false;

                    if (count == K - 1)
                    {
                        jEndtIndex = i;
                    }
                    else if (count == K)
                    {
                        kEndtIndex = i;
                    }
                }
            }
        }

        var ansBuilder = new StringBuilder();
        ansBuilder.Append(S0.AsSpan(0, jStartIndex));
        ansBuilder.Append(S0.AsSpan(kStartIndex, kEndtIndex - kStartIndex));
        ansBuilder.Append(S0.AsSpan(jStartIndex, jEndtIndex - jStartIndex));
        ansBuilder.Append(S0.AsSpan(jEndtIndex, kStartIndex - jEndtIndex));
        ansBuilder.Append(S0.AsSpan(kEndtIndex, S0.Length - 1 - kEndtIndex));

        var ans = ansBuilder.ToString();
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
