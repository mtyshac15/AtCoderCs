using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace AtCoderCs.Common.Models;

public class Writer
{
    private TextWriter _writer;

    public Writer(TextWriter writer)
    {
        _writer = writer;
    }

    public void WriteLine(object? value = null)
    {
        _writer.WriteLine(value);
    }

    public void WriteYesOrNo(bool value)
    {
        WriteLine(ToYesOrNo(value));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }

    public void WriteGrid<T>(T[,] grid)
    {
        var row = grid.GetLength(0);
        var col = grid.GetLength(1);

        var list = new List<string>();
        var line = new T[col];
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                line[j] = grid[i, j];
            }

            list.Add(string.Concat(line));
        }

        this.WriteLine(string.Join(Environment.NewLine, list));
    }
}
