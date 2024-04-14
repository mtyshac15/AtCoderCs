using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace AtCoderCs.Common.Library;

public class Writer
{
    private TextWriter _writer = Console.Out;

    public Writer()
    {
    }

    private void Initialize(TextWriter writer)
    {
        this._writer = writer;
    }

    public void WriteLine(object value = null)
    {
        _writer.WriteLine(value);
    }
}
