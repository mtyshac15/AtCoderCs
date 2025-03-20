using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC367;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void OldC()
    {
        var N = _reader.Int();
        var K = _reader.Int();
        var R = _reader.IntArray();

        var ansBuilder = new StringBuilder();


        var set = new HashSet<int>();
        for (int i1 = 1; i1 <= 5; i1++)
        {
            for (int i2 = 1; i2 <= 5; i2++)
            {
                for (int i3 = 1; i3 <= 5; i3++)
                {
                    for (int i4 = 1; i4 <= 5; i4++)
                    {
                        for (int i5 = 1; i5 <= 5; i5++)
                        {
                            for (int i6 = 1; i6 <= 5; i6++)
                            {
                                for (int i7 = 1; i7 <= 5; i7++)
                                {
                                    for (int i8 = 1; i8 <= 5; i8++)
                                    {
                                        var array = new int[] { i1, i2, i3, i4, i5, i6, i7, i8 };

                                        var num = int.Parse(string.Concat(array.Take(N)));

                                        var sum = num.ToString().ToCharArray().Select(x => int.Parse(x.ToString())).Sum();
                                        if (sum % K == 0)
                                        {
                                            set.Add(num);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        foreach (var num in set)
        {
            var numArray = num.ToString().ToCharArray().Select(x => int.Parse(x.ToString())).ToList();

            var isOk = true;
            for (int digit = 0; digit < N; digit++)
            {
                if (numArray[digit] > R[digit])
                {
                    isOk = false;
                    break;
                }
            }

            if (isOk)
            {
                var element = string.Join(" ", numArray);
                ansBuilder.AppendLine(element);
            }
        }

        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
