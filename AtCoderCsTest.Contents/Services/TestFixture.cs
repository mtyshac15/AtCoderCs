namespace AtCoderCsTest.Contents.Services;

public class TestFixture
{
    private static readonly string _projectName = "AtCoderCsTest.Contest.Tests.csproj";
    private static DirectoryInfo _solutionDirectory;

    static TestFixture()
    {
        var directory = new DirectoryInfo(Environment.CurrentDirectory);
        _solutionDirectory = GetDirectory(directory);
    }

    public TestFixture()
    {
    }

    public ISampleRepository GetSampleRepository(string sampleDirectory)
    {
        var fullPath = Path.Combine(_solutionDirectory.FullName, sampleDirectory);
        var baseDirectoryPath = new DirectoryInfo(fullPath);
        return new SampleRepository(baseDirectoryPath);
    }

    private static DirectoryInfo GetDirectory(DirectoryInfo directory)
    {
        var path = Path.Combine(directory.FullName, _projectName);
        if (File.Exists(path))
        {
            return directory;
        }

        if (directory.Parent != null)
        {
            return GetDirectory(directory.Parent);
        }

        throw new DirectoryNotFoundException();
    }
}