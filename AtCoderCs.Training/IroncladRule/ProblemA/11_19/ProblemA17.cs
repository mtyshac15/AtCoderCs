using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.A17;

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
    var N = _reader.Int();
    var A = _reader.IntArray();
    var B = _reader.IntArray();

    var dp = new int[N];
    dp[0] = 0;
    dp[1] = A[0];

    for (int i = 2; i < N; i++)
    {
      dp[i] = Math.Min(dp[i - 1] + A[i - 1], dp[i - 2] + B[i - 2]);
    }

    //復元
    var list = new List<int>();

    var current = N - 1;
    while (current > 0)
    {
      if (dp[current] - dp[current - 1] == A[current - 1])
      {
        list.Add(current + 1);
        current--;
      }
      else if (dp[current] - dp[current - 2] == B[current - 2])
      {
        list.Add(current + 1);
        current -= 2;
      }
    }

    list.Add(1);
    list.Reverse();

    var ansBuilder = new StringBuilder();
    ansBuilder.AppendLine($"{list.Count}");
    ansBuilder.AppendLine($"{string.Join(" ", list)}");

    var ans = ansBuilder.ToString();
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
