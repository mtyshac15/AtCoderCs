using AtCoderCs.Common.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Training.Tests.Library;

[Trait("Category", "learning")]
public class UnionFindTest
{
    private ITestOutputHelper _output;

    public UnionFindTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void 要素を統合()
    {
        _output.WriteLine("Arrange");
        var N = 5;
        var array = Enumerable.Range(0, 5).ToArray();

        _output.WriteLine("Act");
        var unionFind = new UnionFind(N);
        unionFind.Unite(array[0], array[2]);
        unionFind.Unite(array[1], array[3]);

        _output.WriteLine("Assert");
        Assert.Equal(2, unionFind.Size(array[0]));
        Assert.Equal(2, unionFind.Size(array[1]));
        Assert.Equal(2, unionFind.Size(array[2]));
        Assert.Equal(2, unionFind.Size(array[3]));
        Assert.Equal(1, unionFind.Size(array[4]));
    }
}
