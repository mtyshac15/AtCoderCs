using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC157;

public class MySolution
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public void OldB()
    {
        var gridNum = 3;
        var A = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

            for (int j = 0; j < 3; j++)
            {
                A[i, j] = input[j];
            }
        }

        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var b = new int[N];
        for (int i = 0; i < N; i++)
        {
            b[i] = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        }

        var judgeList = new bool[gridNum, gridNum];

        for (var i = 0; i < gridNum; i++)
        {
            for (var j = 0; j < gridNum; j++)
            {
                //数字をマーク
                var num = A[i, j];
                if (b.Contains(num))
                {
                    judgeList[i, j] = true;
                }
            }
        }

        //ビンゴかどうかチェック
        //横
        for (var i = 0; i < gridNum; i++)
        {
            if (judgeList[i, 0] & judgeList[i, 1] & judgeList[i, 2])
            {
                _writer.WriteLine(IOLibrary.ToYesOrNo(true));
                return;
            }
        }

        //縦
        for (var i = 0; i < gridNum; i++)
        {
            if (judgeList[0, i] & judgeList[1, i] & judgeList[2, i])
            {
                _writer.WriteLine(IOLibrary.ToYesOrNo(true));
                return;
            }
        }

        //ななめ
        if (judgeList[0, 0] & judgeList[1, 1] & judgeList[2, 2]
            || judgeList[0, 2] & judgeList[1, 1] & judgeList[2, 0])
        {
            _writer.WriteLine(IOLibrary.ToYesOrNo(true));
            return;
        }

        _writer.WriteLine(IOLibrary.ToYesOrNo(false));
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
