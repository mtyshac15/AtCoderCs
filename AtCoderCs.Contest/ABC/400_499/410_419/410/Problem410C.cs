using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC410.ProblemC;

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

    var A = Enumerable.Range(1, N).ToArray();

    var count = 0L;

    var ansList = new List<int>();

    for (int i = 0; i < Q; i++)
    {
      var n = _reader.Int();
      var p = _reader.Int();
      var index = (p - 1 + count) % N;

      if (n == 1)
      {
        var x = _reader.Int();
        A[index] = x;
      }
      else if (n == 2)
      {
        ansList.Add(A[index]);
      }
      else
      {
        count += p;
        count %= N;
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
