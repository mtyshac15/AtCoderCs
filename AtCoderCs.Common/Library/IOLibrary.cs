using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace AtCoderCs.Common.Library;

public static class IOLibrary
{
    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}