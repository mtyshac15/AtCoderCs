using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AtCoderCs.Contest.ABC407.ProblemD;

public class ProblemD
{
  private Reader _reader;
  private Writer _writer;

  private int H;
  private int W;

  private ISet<int> boards = new SortedSet<int>() { 0 };

  public ProblemD(TextReader textReader, TextWriter textWriter)
  {
    _reader = new Reader(textReader);
    _writer = new Writer(textWriter);
  }

  public void Solve()
  {
    H = _reader.Int();
    W = _reader.Int();

    var A = new long[H, W];
    for (int i = 0; i < H; i++)
    {
      for (int j = 0; j < W; j++)
      {
        A[i, j] = _reader.Long();
      }
    }

    for (int h = 0; h < H; h++)
    {
      for (int w = 0; w < W; w++)
      {
        Dfs(0, h, w);
      }
    }

    var max = 0L;

    foreach (var board in boards)
    {
      var score = 0L;

      for (int h = 0; h < H; h++)
      {
        for (int w = 0; w < W; w++)
        {
          var index = h * W + w;
          if (!board.TestBit(index))
          {
            score ^= A[h, w];
          }
        }
      }

      max = Math.Max(score, max);
    }

    var ans = max;
    _writer.WriteLine(ans);
  }

  private void Dfs(int board, int h, int w)
  {
    if (h >= H || w >= W)
    {
      return;
    }

    var nextH = h;
    var nextW = w;

    if (w + 1 < W)
    {
      nextW++;
    }
    else
    {
      nextW = 0;
      nextH++;
    }

    var cell = h * W + w;
    if (board.TestBit(cell))
    {
      // すでに置かれている場合
      Dfs(board, nextH, nextW);
      return;
    }

    //タイルを置かない
    Dfs(board, nextH, nextW);

    // 縦に置く
    var tmpBoard = board.OnBit(cell);
    {
      var nexCell = (h + 1) * W + w;
      if (h + 1 < H
        && !tmpBoard.TestBit(nexCell))
      {
        var nextBoard = tmpBoard.OnBit(nexCell);
        boards.Add(nextBoard);

        Dfs(nextBoard, nextH, nextW);
      }
    }

    // 横に置く
    {
      var nexCell = h * W + w + 1;
      if (w + 1 < W
        && !tmpBoard.TestBit(nexCell))
      {
        var nextBoard = tmpBoard.OnBit(nexCell);
        boards.Add(nextBoard);

        Dfs(nextBoard, nextH, nextW);
      }
    }
  }
}

static class Extensions
{
  public static bool TestBit(this int source, int bit)
  {
    return ((source >> bit) & 1) == 1;
  }

  public static int OnBit(this int source, int bit)
  {
    return source | (1 << bit);
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
