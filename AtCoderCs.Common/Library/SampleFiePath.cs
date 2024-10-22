using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace AtCoderCs.Common.Library;

[Obsolete]
public class SampleFiePath
{
    private static readonly string _solutionName = "AtCoderCs.sln";
    private static readonly DirectoryInfo _directory = new DirectoryInfo(Environment.CurrentDirectory);
    private static string _solutionDirectory = string.Empty;

    private readonly string _problemNumber;

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
