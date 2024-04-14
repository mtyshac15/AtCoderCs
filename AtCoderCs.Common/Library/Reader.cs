using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace AtCoderCs.Common.Library;

public class Reader
{
    private TextReader _reader = Console.In;

    public Reader()
    {
    }

    private void Initialize(TextReader reader)
    {
        _reader = reader;
    }

    public string ReadLine()
    {
        return _reader.ReadLine();
    }
}
