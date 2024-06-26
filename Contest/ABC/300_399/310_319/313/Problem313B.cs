﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AtCoderCs.Contest.ABC313;

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
    /// Who is Saikyo?
    /// </summary>
    public void Solve()
    {
        var NM = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var dic = new Dictionary<int, IList<int>>();
        for (int i = 1; i <= N; i++)
        {
            dic.Add(i, new List<int>());
        }

        //B→Aの辺を追加
        for (int i = 0; i < M; i++)
        {
            var AB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            dic[AB[1]].Add(AB[0]);
        }

        var keyValueArray = dic.Where(x => !x.Value.Any()).ToArray();

        //あるノードを始点とする辺が存在しないノードが一つだけの場合が答え
        var ans = -1;
        if (keyValueArray.Length == 1)
        {
            ans = keyValueArray.FirstOrDefault().Key;
        }

        _writer.WriteLine(ans);
    }
}
