using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.A28;

public class ProblemA
{
  private Reader _reader;
  private Writer _writer;

  public ProblemA(TextReader textReader, TextWriter textWriter)
  {
    _reader = new Reader(textReader);
    _writer = new Writer(textWriter);
  }

  public void Solve()
  {
    var mod = 10_000;

    var N = _reader.Int();
    var T = new string[N];
    var A = new int[N];

    for (int i = 0; i < N; i++)
    {
      T[i] = _reader.Str();
      A[i] = _reader.Int();
    }

    var ansList = new List<int>();

    var result = 0;
    for (int i = 0; i < N; i++)
    {
      switch (T[i])
      {
        case "+":
          result += A[i];
          break;

        case "-":
          result -= A[i];
          break;

        case "*":
          result *= A[i];
          break;

        default:
          break;
      }

      if (result < 0)
      {
        result += mod;
      }
      result %= mod;
      ansList.Add(result);
    }

    var ans = string.Join(Environment.NewLine, ansList);
    _writer.WriteLine(ans);
  }
}

#region
class ProgramA
{
  public static void Main(string[] args)
  {
    Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
    var problem = new ProblemA(Console.In, Console.Out);
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
