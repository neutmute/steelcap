using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace SteelCap
{
    [TargetElement("sc-icon")]
    public class IconHelper : TagHelper
    {
        public string @Class { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            output.Content.SetContent(Get(@Class).ToString());
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
