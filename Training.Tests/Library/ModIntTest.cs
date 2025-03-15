using AtCoderCs.Common.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Training.Tests.Library;

public class ModIntTest
{
    static readonly int _mod = 998244353;

    private ITestOutputHelper _output;

    public ModIntTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void 四則演算()
    {
        var a = 111111111;
        var b = 123456789;
        var c = 987654321;
        var ans = 802336242;

        var ans1 = a * b * c;
        _output.WriteLine($"{ans1}");
        Assert.NotEqual(ans, ans1);

        var ans2 = a * b % ModInt.MOD * c % ModInt.MOD;
        _output.WriteLine($"{ans2}");
        Assert.NotEqual(ans, ans2);

        var ans3 = (long)a * b % ModInt.MOD * c % ModInt.MOD;
        _output.WriteLine($"{ans3}");
        Assert.Equal(ans, ans3);

        var ma = (ModInt)a;
        var mb = (ModInt)b;
        var mc = (ModInt)c;

        var ans4 = ma * mb * mc;
        _output.WriteLine($"{ans4}");
        Assert.Equal(ans, ans4);
    }

    public void 逆元()
    {

    }
}
