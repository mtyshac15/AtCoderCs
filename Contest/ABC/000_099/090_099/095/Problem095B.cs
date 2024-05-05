using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC095;

public class ProblemB
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemB()
    {
    }

    public ProblemB(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Bitter Alchemy
    /// </summary>
    public void Solve()
    {
        var NX = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NX[0];
        var X = NX[1];

        var m = new int[N];
        for (int i = 0; i < N; i++)
        {
            m[i] = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        }

        //�S���1���쐬
        var total = m.Sum();

        //�K�v�ȗʂ��ł����Ȃ����َq�̑f�ō��邾�����
        Array.Sort(m);
        var ans = N + (X - total) / m[0];
        _writer.WriteLine(ans);
    }
}
