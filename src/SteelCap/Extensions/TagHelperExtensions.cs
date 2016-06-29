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


            var classAttribute = target.Attributes["class"];
            var currentClass = string.Empty;

            if (classAttribute == null)
            {
                target.Attributes.SetAttribute("class", string.Empty);
            }
            else
            {
                currentClass = classAttribute.Value.ToString();
                currentClass += " ";
            }
            currentClass += cssClass;
            target.Attributes.SetAttribute("class", currentClass);
        }
    }
}
