using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AtCoderCs.Contest.ABC340;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    public void Solve()
    {
        var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var Q = input[0];

        var list = new List<long>();

        var strtBuilder = new StringBuilder();

        for (var i = 0; i < Q; i++)
        {
            var query = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            var x = query[0];
            var k = query[1];

            if (x == 1)
            {
                list.Add(k);
            }
            else if (x == 2)
            {
                var result = list[list.Count - k];
                strtBuilder.AppendLine($"{result}");
            }
        }

        Console.WriteLine(strtBuilder.ToString());
    }
}
