using AtCoderCs.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Common.Library;

public class SampleInput
{
    private static readonly string _baseFileName = "Input.txt";
    private string _baseFolderPath;
    private SampleDirectory _directory;
    private string? _text;

    public SampleInput(string folderPath)
    {
        _baseFolderPath = folderPath;
    }

    public SampleInput(SampleDirectory directory)
    {
        _directory = directory;
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

    public void Load(string fileSuffix)
    {
        var filePath = FilePath.Create(_directory, $"{fileSuffix}_{_baseFileName}");

        string text;
        using (var reader = new StreamReader(filePath))
        using (var synchronized = StreamReader.Synchronized(reader))
        {
            text = synchronized.ReadToEnd();
        }

        _text = text;
    }

    public static string GetFileName(string fileSuffix)
    {
        return $"{fileSuffix}_{_baseFileName}";
    }

    public StringReader CreateReader()
    {
        if (string.IsNullOrWhiteSpace(_text))
        {
            throw new ArgumentNullException();
        }

        return new StringReader(_text);
    }
}
