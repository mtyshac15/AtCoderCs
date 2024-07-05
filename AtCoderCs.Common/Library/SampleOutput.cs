using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Common.Library;

public class SampleOutput
{
    private static readonly string _baseFileName = "Output.txt";
    private string _baseFolderPath;

    public SampleOutput(string folderPath)
    {
        _baseFolderPath = folderPath;
    }

    public string Read(string fileSuffix)
    {
        var filePath = Path.Combine($"{_baseFolderPath}", $"{fileSuffix}_{_baseFileName}");

        string text;
        using (var reader = new StreamReader(filePath))
        using (var synchronized = StreamReader.Synchronized(reader))
        {
            text = synchronized.ReadToEnd();
        }

        return text;
    }
}
