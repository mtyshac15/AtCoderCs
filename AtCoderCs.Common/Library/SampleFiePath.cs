using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace AtCoderCs.Common.Library;

public class SampleFiePath
{
    private static readonly string _solutionName = "AtCoderCs.sln";
    private static readonly DirectoryInfo _directory = new DirectoryInfo(Environment.CurrentDirectory);
    private static string _solutionDirectory = string.Empty;

    private readonly string _problemNumber;

    private SampleInput _sampleInput;
    private SampleOutput _sampleOutput;

    public SampleFiePath(string contestSection, string problemFolder, string problemNumber)
    {
        if (string.IsNullOrWhiteSpace(_solutionDirectory))
        {
            _solutionDirectory = SampleFiePath.GetDirectory(_directory, _solutionName);
        }

        _problemNumber = problemNumber;

        var array = new string[]
        {
            $"Sample",
            contestSection,
            problemFolder,
            problemNumber,
        }.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        var sampleFolder = Path.Combine(array);

        var sampleFolderPath = Path.Combine($"{_solutionDirectory}", $"{sampleFolder}");
        _sampleInput = new SampleInput(sampleFolderPath);
        _sampleOutput = new SampleOutput(sampleFolderPath);
    }

    public SampleDto ReadFiles(string level, string suffix = "")
    {
        var suffixArray = new string[]
        {
            $"{_problemNumber}{level}",
            suffix,
        }.Where(x => !string.IsNullOrWhiteSpace(x));

        var fileSuffix = string.Join("_", suffixArray);

        string inputText = _sampleInput.Read(fileSuffix);
        string outputText = _sampleOutput.Read(fileSuffix);

        return new SampleDto(inputText, outputText);
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
