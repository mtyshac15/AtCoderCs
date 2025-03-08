using AtCoderCs.Common.Library;
using AtCoderCs.Common.ValueObjects;
using Contest.Tests.Services;
using Xunit.Abstractions;

namespace AtCoderCs.Contest.Tests;

public class TestFixture
{
    private static readonly string _solutionName = "AtCoderCs.sln";
    private static DirectoryInfo? _solutionDirectory;

    private SampleDirectory _baseDirectory;

    public TestFixture()
    {
        if (_solutionDirectory is null)
        {
            var directory = new DirectoryInfo(Environment.CurrentDirectory);
            _solutionDirectory = GetDirectory(directory, _solutionName);
        }
    }

    public DirectoryInfo GetBaseDirectory(string contestSection, string problemFolder, string problemNumber)
    {
        if (_solutionDirectory is null)
        {
            var directory = new DirectoryInfo(Environment.CurrentDirectory);
            _solutionDirectory = GetDirectory(directory, _solutionName);
        }

        var array = new string[]
        {
            $"Sample",
            contestSection,
            problemFolder,
            problemNumber,
        }.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        var sampleFolder = Path.Combine(array);

        var fullPath = Path.Combine(_solutionDirectory.FullName, sampleFolder);
        return new DirectoryInfo(fullPath);
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

        var fullPath = Path.Combine(_solutionDirectory.FullName, sampleFolder);
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

    private static DirectoryInfo GetDirectory(DirectoryInfo directory, string fileName)
    {
        var path = Path.Combine(directory.FullName, fileName);
        if (File.Exists(path))
        {
            return directory;
        }

        if (directory.Parent != null)
        {
            return GetDirectory(directory.Parent, fileName);
        }

        throw new DirectoryNotFoundException();
    }
}