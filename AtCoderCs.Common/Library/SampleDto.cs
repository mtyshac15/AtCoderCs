using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Common.Library;

public class SampleDto
{
    public SampleDto(string input, string output)
    {
        this.Input = input;
        this.Output = output;
    }

    public string Input { get; }

    public string Output { get; }
}
