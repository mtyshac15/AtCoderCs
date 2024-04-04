using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Contest.ABC339;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    public void Solve()
    {
        var S = Console.ReadLine().Trim();
        var array = S.Split('.');
        Console.WriteLine(array[array.Length - 1]);
    }
}
