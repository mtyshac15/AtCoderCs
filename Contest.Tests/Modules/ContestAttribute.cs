using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contest.Tests.Modules;

[AttributeUsage(AttributeTargets.Class)]
internal class ContestAttribute : Attribute
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="section"></param>
    /// <param name="number"></param>
    public ContestAttribute(string section, string number)
    {
        Section = section;
        Number = number;
    }

    /// <summary>
    /// コンテストの種別を取得します。
    /// </summary>
    public string Section { get; }

    /// <summary>
    /// コンテストの番号を取得します。
    /// </summary>
    public string Number { get; }

    public override string ToString()
    {
        return $"{this.Section} {this.Number}";
    }
}
