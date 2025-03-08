using AtCoderCs.Common.Library;

namespace Contest.Tests.Services;

public interface ISampleRepository
{
    SampleSet Find(string level);
}