using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC395.ProblemD;

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
        var Q = _reader.Int();

        var op = new List<int[]>();
        for (int i = 0; i < Q; i++)
        {
            op.Add(_reader.IntArray());
        }

        // 各鳩がいる巣
        var pigeonToBox = Enumerable.Range(1, N)
             .ToDictionary(x => x, x => x);
        // 各巣に入っているラベル鳩
        var boxToLabel = Enumerable.Range(1, N)
             .ToDictionary(x => x, x => x);
        // 各ラベル鳩が入っている巣
        var labelToBox = Enumerable.Range(1, N)
             .ToDictionary(x => x, x => x);

        var ansList = new List<int>();
        for (int i = 0; i < Q; i++)
        {
            var num = op[i][0];
            var a = op[i][1];

            if (num == 1)
            {
                var b = op[i][2];
                pigeonToBox[a] = labelToBox[b];
            }
            else if (num == 2)
            {
                var b = op[i][2];
                {
                    // ラベルを貼っている箱を入れ替える
                    var tmp = labelToBox[a];
                    labelToBox[a] = labelToBox[b];
                    labelToBox[b] = tmp;
                }

                {
                    // 箱のラベルを更新
                    var tmp = boxToLabel[labelToBox[a]];
                    boxToLabel[labelToBox[a]] = boxToLabel[labelToBox[b]];
                    boxToLabel[labelToBox[b]] = tmp;
                }
            }
            else
            {
                ansList.Add(boxToLabel[pigeonToBox[a]]);
            }
        }

        var ans = string.Join(Environment.NewLine, ansList);
        _writer.WriteLine(ans);
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
