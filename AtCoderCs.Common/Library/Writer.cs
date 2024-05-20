using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace AtCoderCs.Common.Library;

public class Writer
{
    private TextWriter _writer;

    public Writer()
       : this(Console.Out)
    {
    }

    public Writer(TextWriter writer)
    {
        _writer = writer;
    }

    public void WriteLine(object value = null)
    {
        _writer.WriteLine(value);
    }

    public void WriteYesOrNo(bool value)
    {
        this.WriteLine(Writer.ToYesOrNo(value));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
