using AtCoderCs.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Common.Library;

public class SampleSet
{
    public SampleSet(SampleInput input, SampleOutput output)
    {
        this.InputReader = input.CreateReader();
        this.OutputReader = output.CreateReader();
    }

    public StringReader InputReader { get; }

    public StringReader OutputReader { get; }
}
