using AtCoderCs.Common.Library;
using AtCoderCs.Common.ValueObjects;

namespace AtCoderCs.Contest.Tests;

public class TestFixture
{
    private static readonly string _solutionName = "AtCoderCs.sln";
    private static string _solutionDirectory;

    private SampleDirectory _baseDirectory;

    public TestFixture()
    {
        if (string.IsNullOrWhiteSpace(_solutionDirectory))
        {
            var directory = new DirectoryInfo(Environment.CurrentDirectory);
            _solutionDirectory = TestFixture.GetDirectory(directory, _solutionName);
        }
    }

    public void ConfigureSampleFolder(string contestSection, string problemFolder, string problemNumber)
    {
        var array = new string[]
        {
            $"Sample",
            contestSection,
            problemFolder,
            problemNumber,
        }.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        var sampleFolder = Path.Combine(array);

        var fullPath = Path.Combine(_solutionDirectory, sampleFolder);
        _baseDirectory = SampleDirectory.Create(new DirectoryInfo(fullPath));
    }

    public SampleSet ReadFiles(string number, string level, string suffix = "")
    {
        var suffixArray = new string[]
        {
            $"{number}{level}",
            suffix,
        }.Where(x => !string.IsNullOrWhiteSpace(x));

        var fileNum = string.Join("_", suffixArray);
        return SampleSet.LoadSample(_baseDirectory, fileNum);
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
            return TestFixture.GetDirectory(directory.Parent, fileName);
        }

        return string.Empty;
    }
}