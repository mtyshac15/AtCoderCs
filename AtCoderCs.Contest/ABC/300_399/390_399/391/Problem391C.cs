using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC391.ProblemC;

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
        var Q = _reader.Int();

        var queryies = new int[Q][];
        for (int i = 0; i < Q; i++)
        {
            queryies[i] = _reader.IntArray();
        }

        var count = 0;

        var bigeons = Enumerable.Range(1, N).ToDictionary(key => key, value => value);
        var boxes = Enumerable.Range(1, N).ToDictionary(key => key, value => 1);

        var ansList = new List<int>();
        for (int i = 0; i < Q; i++)
        {
            var num = queryies[i][0];
            switch (num)
            {
                case 1:
                    var P = queryies[i][1];
                    var H = queryies[i][2];

                    var preBox = bigeons[P];

                    // 鳩を移動
                    bigeons[P] = H;

                    // 移動前の巣
                    boxes[preBox]--;
                    if (boxes[preBox] == 1)
                    {
                        // 移動した後の鳩の羽数が1の場合、複数匹の鳩のいる巣は1つ減る
                        count--;
                    }

                    // 移動後
                    boxes[H]++;
                    if (boxes[H] == 2)
                    {
                        // 移動した後の鳩の羽数が2の場合、複数匹鳩のいる巣は1つ増える
                        count++;
                    }

                    break;

                case 2:
                    ansList.Add(count);
                    break;
            }
        }

        var ans = string.Join(Environment.NewLine, ansList);
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
