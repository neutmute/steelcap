using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.WebEncoders;

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
