using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AtCoderCs.Common.Library;

public class SampleFiePath
{
    private static readonly string _solutionName = "AtCoderCs.sln";

    private static readonly string _inputFileName = "Input.txt";
    private static readonly string _outputFileName = "Output.txt";

    private static string _sampleFolder;

    public SampleFiePath(string contestSection, string problemFolder, string problemNumber)
    {
        var directory = new DirectoryInfo(Environment.CurrentDirectory);
        var solutionDirectory = SampleFiePath.GetDirectory(directory, _solutionName);
        _sampleFolder = Path.Combine($"{solutionDirectory}",
                                     $"Sample",
                                     $"{contestSection}",
                                     $"{problemFolder}",
                                     $"{problemNumber}");
    }

    public (string Input, string Output) Generate(string level)
    {
        var inputFilePath = $"{_sampleFolder}{level}_{_inputFileName}";
        var outputFilePath = $"{_sampleFolder}{level}_{_outputFileName}";
        return (inputFilePath, outputFilePath);
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
