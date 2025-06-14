using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.B61;

public class ProblemB
{
  private Reader _reader;
  private Writer _writer;

  public static void Main(string[] args)
  {
    Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
    var problem = new ProblemB(Console.In, Console.Out);
    problem.Solve();
    Console.Out.Flush();
  }

  public ProblemB(TextReader textReader, TextWriter textWriter)
  {
    _reader = new Reader(textReader);
    _writer = new Writer(textWriter);
  }

  public void Solve()
  {
    var R = _reader.Int();
    var C = _reader.Int();

    var sy = _reader.Int();
    var sx = _reader.Int();
    var gy = _reader.Int();
    var gx = _reader.Int();

    var c = new char[R, C];
    for (int i = 0; i < R; i++)
    {
      var line = _reader.Str();
      for (int j = 0; j < C; j++)
      {
        c[i, j] = line[j];
      }
    }

    var dx = new int[] { 1, 0, -1, 0 };
    var dy = new int[] { 0, 1, 0, -1 };

    var distance = new int[R, C];
    for (int i = 0; i < R; i++)
    {
      for (int j = 0; j < C; j++)
      {
        distance[i, j] = -1;
      }
    }

    Func<int, int, bool> inside = (x, y) =>
    {
      return x >= 0 && x < C && y >= 0 && y < R;
    };

    var queue = new Queue<(int Y, int X)>();
    queue.Enqueue((sy - 1, sx - 1));

    distance[sx - 1, sy - 1] = 0;

    while (queue.Any())
    {
      var current = queue.Dequeue();
      for (int i = 0; i < 4; i++)
      {
        var to = current;
        to.X += dx[i];
        to.Y += dy[i];

        if (inside(to.X, to.Y)
          && c[to.Y, to.X] != '#'
          && distance[to.Y, to.X] == -1)
        {
          distance[to.Y, to.X] = distance[current.Y, current.X] + 1;
          queue.Enqueue(to);
        }
      }
    }

    var ans = distance[gy - 1, gx - 1];
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

