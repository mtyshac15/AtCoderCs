using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.A26;

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
    var Q = _reader.Int();
    var X = new int[Q];
    for (int i = 0; i < Q; i++)
    {
      X[i] = _reader.Int();
    }

    var ansList = new List<string>();
    for (int i = 0; i < Q; i++)
    {
      var isPrime = MathLibrary.IsPrime(X[i]);
      ansList.Add(Writer.ToYesOrNo(isPrime));
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

public static class MathLibrary
{
  #region "約数、素数"
  /// <summary>
  /// 素数判定
  /// </summary>
  /// <param name="n"></param>
  /// <returns></returns>
  public static bool IsPrime(long n)
  {
    for (long i = 2; i * i <= n; i++)
    {
      if (n % i == 0)
      {
        return false;
      }
    }
    return true;
  }

  public static int[] Primes(int n)
  {
    var primes = new bool[n + 1];
    for (int i = 0; i < n; i++)
    {
      primes[i] = true;
    }

    primes[0] = false;
    primes[1] = false;

    for (int i = 2; i * i <= n; i++)
    {
      if (IsPrime(i))
      {
        for (int j = i * i; j <= n; j += i)
        {
          primes[j] = false;
        }
      }
    }

    // リストに変換
    return primes.Where(e => e).Select((e, i) => i).ToArray();
  }
  #endregion
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
