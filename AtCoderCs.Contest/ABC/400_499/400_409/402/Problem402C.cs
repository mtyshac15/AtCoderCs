using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC402.ProblemC;

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
        var M = _reader.Int();

        var K = new int[M];
        var A = new int[M][];

        for (int i = 0; i < M; i++)
        {
            K[i] = _reader.Int();
            var array = new int[K[i]];
            for (int j = 0; j < K[i]; j++)
            {
                array[j] = _reader.Int();
            }

            A[i] = array;
        }

        var B = _reader.IntArray()
            .Select((b, i) => (b, i))
            .ToDictionary(key => key.b, value => value.i);

        var C = new int[N];
        for (int i = 0; i < M; i++)
        {
            var max = 0;
            for (int j = 0; j < K[i]; j++)
            {
                max = Math.Max(B[A[i][j]], max);
            }

            C[max]++;
        }

        var ansArray = new int[N];
        ansArray[0] = C[0];
        for (int i = 0; i < N - 1; i++)
        {
            ansArray[i + 1] = ansArray[i] + C[i + 1];
        }

        var ans = string.Join(Environment.NewLine, ansArray);
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
