using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Contest.ABC329;

public class MySolution
{
    public void OldB()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var array = A.Distinct().ToArray();
        Array.Sort(array);

        var ans = array[array.Length - 2];
        Console.WriteLine(ans);
    }
}
