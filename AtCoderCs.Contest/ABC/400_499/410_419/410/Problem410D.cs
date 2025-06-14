using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC410.ProblemD;

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
    var M = _reader.Int();

    var A = new int[M];
    var B = new int[M];
    var W = new int[M];

    //隣接リストを作成
    var graph = new List<IList<(int To, int W)>>();
    for (int i = 0; i < N + 1; i++)
    {
      graph.Add(new List<(int, int)>());
    }

    for (int i = 0; i < M; i++)
    {
      graph[A[i]].Add((B[i], W[i]));
    }

    var min = int.MaxValue;

    var ans = min;
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
