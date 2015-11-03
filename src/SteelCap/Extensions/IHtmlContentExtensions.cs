using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNet.Html.Abstractions;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Framework.WebEncoders;

namespace SteelCap.Extensions
{
    public static class IHtmlContentExtensions
    {
        public static string ToHtml(this IHtmlContent target)
        {
            string s;
            using (var sw = new StringWriter())
            {
                target.WriteTo(sw, HtmlEncoder.Default);
                s = sw.ToString();
            }
            return s;
        }
    }
}
