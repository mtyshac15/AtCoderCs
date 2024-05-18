using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC095;
public class ProblemC
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = input[0];
        var B = input[1];
        var C = input[2];
        var X = input[3];
        var Y = input[4];

        var ans = int.MaxValue;

        //ABÇÃÇ›ÇîÉÇ¡ÇΩèÍçáÇÃç≈ëÂêî
        var maxAb = Math.Max(X, Y) * 2;
        for (int ab = 0; ab <= maxAb; ab += 2)
        {
            //AÇÃë„ã‡
            var countA = Math.Max(X - ab / 2, 0);
            var totalA = A * countA;

            //BÇÃë„ã‡
            var countB = Math.Max(Y - ab / 2, 0);
            var totalB = B * countB;

            //CÇÃë„ã‡
            var totalC = C * ab;

            var total = totalA + totalB + totalC;
            ans = Math.Min(total, ans);
        }

        _writer.WriteLine(ans);
    }
}
