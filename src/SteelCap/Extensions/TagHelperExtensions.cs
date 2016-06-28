using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SteelCap.Extensions
{
    public static class TagHelperExtensions
    {
        public static void AppendClass(this TagHelperOutput target, string cssClass)
        {
            if (string.IsNullOrWhiteSpace(cssClass))
            {
                return;
            }

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
