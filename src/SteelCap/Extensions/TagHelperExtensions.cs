using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace SteelCap.Extensions
{
    public static class HtmlStringExtensions
    {
        public static HtmlString Concat(this HtmlString first, string html)
        {
            return Concat(first, new HtmlString(html));
        }

        public static HtmlString Concat(this HtmlString first, params HtmlString[] htmlStringsForConcat)
        {
            var sb = new StringBuilder();
            sb.Append(first);
            foreach (var htmlString in htmlStringsForConcat)
            {
                sb.Append(htmlString);
            }
            return new HtmlString(sb.ToString());
        }
    }

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
