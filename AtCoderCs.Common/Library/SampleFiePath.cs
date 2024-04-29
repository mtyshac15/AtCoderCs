using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace AtCoderCs.Common.Library;

public class SampleFiePath
{
    private static readonly string _solutionName = "AtCoderCs.sln";
    private static readonly DirectoryInfo _directory = new DirectoryInfo(Environment.CurrentDirectory);
    private static string _solutionDirectory;

    private static readonly string _inputFileName = "Input.txt";
    private static readonly string _outputFileName = "Output.txt";

    private string _sampleFolderPath;

    public SampleFiePath(string contestSection, string problemFolder, string problemNumber)
    {
        if (string.IsNullOrWhiteSpace(_solutionDirectory))
        {
            _solutionDirectory = SampleFiePath.GetDirectory(_directory, _solutionName);
        }

        var sampleFolder = Path.Combine($"Sample",
                                        $"{contestSection}",
                                        $"{problemFolder}",
                                        $"{problemNumber}",
                                        $"{problemNumber}");

        _sampleFolderPath = Path.Combine($"{_solutionDirectory}", $"{sampleFolder}");
    }

    public (string InputText, string OutputText) ReadFiles(string level, string suffix = "")
    {
        var inputFileName = _inputFileName;
        var outputFileName = _outputFileName;

        if (!string.IsNullOrWhiteSpace(suffix))
        {
            inputFileName = $"{suffix}_{inputFileName}";
            outputFileName = $"{suffix}_{outputFileName}";
        }

        var inputFilePath = $"{_sampleFolderPath}{level}_{inputFileName}";

        string inputText;
        using (var reader = new StreamReader(inputFilePath))
        using (var synchronized = StreamReader.Synchronized(reader))
        {
            inputText = synchronized.ReadToEnd();
        }

        var outputFilePath = $"{_sampleFolderPath}{level}_{outputFileName}";

        string outputText;
        using (var reader = new StreamReader(outputFilePath))
        using (var synchronized = StreamReader.Synchronized(reader))
        {
            outputText = synchronized.ReadToEnd();
        }

        return (inputText, outputText);
    }

    private static string GetDirectory(DirectoryInfo directory, string fileName)
    {
        var path = Path.Combine(directory.FullName, fileName);
        if (File.Exists(path))
        {
            return directory.FullName;
        }

        if (directory.Parent != null)
        {
            return SampleFiePath.GetDirectory(directory.Parent, fileName);
        }

        return string.Empty;
    }
}
