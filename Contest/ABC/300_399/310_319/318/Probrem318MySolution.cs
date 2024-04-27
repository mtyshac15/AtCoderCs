using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC318;

public class MySolution
{
    public void OlAdA()
    {
        var NMP = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NMP[0];
        var M = NMP[1];
        var P = NMP[2];

        var ans = 0;
        if (N - M >= 0)
        {
            ans++;
        }

        ans += (N - M) / P;
        Console.WriteLine(ans);
    }
}
