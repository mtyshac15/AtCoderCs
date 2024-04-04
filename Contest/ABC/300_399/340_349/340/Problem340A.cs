using System.Text;

namespace AtCoderCs.Contest.ABC340;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    public void Solve()
    {
        var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = input[0];
        var B = input[1];
        var D = input[2];

        var list = new List<int>();

        var result = A;
        while (result <= B)
        {
            list.Add(result);
            result += D;
        }

        var ans = string.Join(" ", list);
        Console.WriteLine(ans);
    }
}
