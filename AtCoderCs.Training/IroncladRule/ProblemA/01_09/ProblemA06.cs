using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.A06;

public class ProblemA
{
  private Reader _reader;
  private Writer _writer;

  public static void Main(string[] args)
  {
    Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
    var problem = new ProblemA(Console.In, Console.Out);
    problem.Solve();
    Console.Out.Flush();
  }

  public ProblemA(TextReader textReader, TextWriter textWriter)
  {
    _reader = new Reader(textReader);
    _writer = new Writer(textWriter);
  }

  public void Solve()
  {
    var N = _reader.Int();
    var Q = _reader.Int();
    var A = _reader.IntArray();

    var L = new List<int>();
    var R = new List<int>();
    for (int i = 0; i < Q; i++)
    {
      L.Add(_reader.Int());
      R.Add(_reader.Int());
    }

    //累積和
    var sumA = new List<int>() { 0 };
    for (int i = 0; i < A.Length; i++)
    {
      sumA.Add(sumA[i] + A[i]);
    }

    var ansList = new List<int>();
    for (int i = 0; i < Q; i++)
    {
      var count = sumA[R[i]] - sumA[L[i] - 1];
      ansList.Add(count);
    }

    var ans = string.Join(Environment.NewLine, ansList);
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
