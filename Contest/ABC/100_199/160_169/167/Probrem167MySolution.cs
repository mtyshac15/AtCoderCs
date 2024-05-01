using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC167;

public class MySolution
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public void OldB()
    {
        var S = _reader.ReadLine().Trim();
        var T = _reader.ReadLine().Trim();
        var last = T[T.Length - 1];
        _writer.WriteLine(IOLibrary.ToYesOrNo(S + last.ToString() == T));
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
