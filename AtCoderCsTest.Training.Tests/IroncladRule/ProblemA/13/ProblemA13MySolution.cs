using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.Tests.A13;

public class MySolution
{
  private Reader _reader;
  private Writer _writer;

  public MySolution()
  {
    _reader = new Reader(Console.In);
    _writer = new Writer(Console.Out);
  }

  public void Solve()
  {
    var N = _reader.Int();
    var K = _reader.Int();
    var A = _reader.IntArray();

    var count = 0L;

    for (int i = 0; i < N; i++)
    {
      Func<int, bool> judge = (mIndex) =>
      {
        return Math.Abs(A[mIndex] - A[i]) <= K;
      };

      var index = BinarySerch(i, A.Length, judge);
      count += index - i;
    }

    var ans = count;
    _writer.WriteLine(ans);
  }

  private int BinarySerch(int ok, int ng, Func<int, bool> judge)
  {
    while (Math.Abs(ok - ng) > 1)
    {
      var min = Math.Min(ok, ng);
      var max = Math.Max(ok, ng);

      var middle = min + (max - min) / 2;
      if (judge(middle))
      {
        ok = middle;
      }
      else
      {
        ng = middle;
      }
    }

    return ok;
  }
}
