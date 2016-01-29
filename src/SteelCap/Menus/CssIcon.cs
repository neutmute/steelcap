using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteelCap
{
    public class CssIcon
    {
        public string Value { get; }

        public CssIcon(string css)
        {
            Value = css;
        }

        public override string ToString()
        {
            return Value;
        }

        public static readonly CssIcon Null = new CssIcon(null);
    }

    public static class CssIconExtensions
    {
        public static bool IsNull(this CssIcon target)
        {
            return target == null || string.IsNullOrEmpty(target.Value);
        }
    }
}
