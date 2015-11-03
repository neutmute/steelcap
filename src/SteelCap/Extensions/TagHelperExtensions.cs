using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace SteelCap.Extensions
{
    public static class TagHelperExtensions
    {
        public static void AppendClass(this TagHelperOutput target, string cssClass)
        {
            if (target.Attributes["class"] == null)
            {
                target.Attributes["class"] = string.Empty;
            }
            else
            {
                target.Attributes["class"].Value += " ";
            }
            target.Attributes["class"].Value += cssClass;
        }
    }
}
