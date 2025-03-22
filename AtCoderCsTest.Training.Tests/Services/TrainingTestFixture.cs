using AtCoderCsTest.Contents.Services;

namespace AtCoderCsTest.Training.Tests.Services;

public class TrainingTestFixture
{
    private static readonly string _projectName = "AtCoderCsTest.Training.Tests.csproj";
    private static DirectoryInfo _solutionDirectory;

    static TrainingTestFixture()
    {
        var directory = new DirectoryInfo(Environment.CurrentDirectory);
        _solutionDirectory = TrainingTestFixture.GetDirectory(directory, _projectName);
    }

    public TrainingTestFixture()
    {
    }

    public ISampleRepository GetSampleRepository(string sampleDirectory)
    {
        var fullPath = Path.Combine(_solutionDirectory.FullName, sampleDirectory);
        var baseDirectoryPath = new DirectoryInfo(fullPath);
        return new SampleRepository(baseDirectoryPath);
    }

    private static DirectoryInfo GetDirectory(DirectoryInfo directory, string projectName)
    {
        var path = Path.Combine(directory.FullName, projectName);
        if (File.Exists(path))
        {
            return directory;
        }

        if (directory.Parent != null)
        {
            return GetDirectory(directory.Parent, projectName);
        }

        throw new DirectoryNotFoundException();
    }
}
