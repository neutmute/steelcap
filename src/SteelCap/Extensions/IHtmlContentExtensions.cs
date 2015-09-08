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
    ///// <summary>
    ///// Dirty hack for Beta7 until they improve the API
    ///// http://stackoverflow.com/questions/32416425/tagbuilder-innerhtml-in-asp-net-5-mvc-6
    ///// </summary>
    //public class RawHtml : IHtmlContent
    //{
    //    private readonly string _html;
    //    public RawHtml(string html)
    //    {
    //        _html = html;
    //    }
    //    public void WriteTo(TextWriter writer, IHtmlEncoder encoder)
    //    {
    //        writer.Write(_html);
    //    }
    //}

    public static class IHtmlContentExtensions
    {
        /// <summary>
        /// Dirty hack for Beta7 until they improve the API
        /// http://stackoverflow.com/questions/32416425/tagbuilder-innerhtml-in-asp-net-5-mvc-6
        /// </summary>
        public static string ConcatToString(this IHtmlContent target, params IHtmlContent[] contents)
        {
            var contentList = contents.ToList();
            contentList.Insert(0, target);
            return ConcatToString(contentList);
        }

        public static IHtmlContent ConcatToHtmlContent(this IHtmlContent target, params IHtmlContent[] contents)
        {
            return new HtmlString(ConcatToString(target, contents));
        }

        public static string ConcatToString(this List<IHtmlContent> target)
        {
            string s;
            using (var sw = new StringWriter())
            {
                foreach (var content in target)
                {
                    content.WriteTo(sw, HtmlEncoder.Default);
                }

                s = sw.ToString();
            }
            return s;
        }
    }
}
