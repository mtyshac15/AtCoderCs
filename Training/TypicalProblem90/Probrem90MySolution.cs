using AtCoderCs.Common.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC000;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void Old001()
    {
        var N = _reader.NextInt();
        var L = _reader.NextInt();
        var K = _reader.NextInt();
        var A = _reader.NextIntArray();

        //階差
        var newA = A.Prepend(0).Append(L);
        var diff = newA.Skip(1);
        var collection = diff.Zip(newA, (e1, e2) => e1 - e2);

        var ok = 0L;
        var ng = L;

        Func<long, bool> isOk = (x) =>
        {
            //分割数
            var count = 0L;
            var length = 0L;
            foreach (var item in collection)
            {
                length += item;
                if (length >= x)
                {
                    //長さがxに達した場合はそこで切る
                    count++;
                    length = 0;
                }
            }

            return count >= K + 1;
        };

        var ans = MathLibrary.BinarySearch(ok, ng, isOk);
        _writer.WriteLine(ans);
    }

    #region ""
    class MathLibrary
    {
        public static long BinarySearch(long initOk, long initNg, Func<long, bool> isOk)
        {
            var ok = initOk;
            var ng = initNg;

            while (Math.Abs(ok - ng) > 1)
            {
                //区間の中央
                var middle = ok + (ng - ok) / 2;
                if (isOk(middle))
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
    #endregion
}
