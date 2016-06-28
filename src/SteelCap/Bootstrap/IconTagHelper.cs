using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SteelCap.Extensions;

namespace SteelCap
{
    [HtmlTargetElement("sc-icon")]
    public class IconHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "i";
            BaseCssClass.ForEach(output.AppendClass);
            base.Process(context, output);
        }

        static IconHelper()
        {
            BaseCssClass = new List<string>();
        }

        /// <summary>
        /// Configure these at Startup.cs, with "fa", "ace-icon" etc
        /// </summary>
        public static List<string> BaseCssClass { get; private set; }

        public static TagBuilder Get(params string[] cssClasses)
        {
            var iconBuilder = new TagBuilder("i");
            BaseCssClass.ForEach(iconBuilder.AddCssClass);

            cssClasses?.ToList().ForEach(s => iconBuilder.AddCssClass(s));

            return iconBuilder;
        }
    }
}
