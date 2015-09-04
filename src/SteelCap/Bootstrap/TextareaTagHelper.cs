using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using SteelCap.Extensions;

namespace SteelCap.Bootstrap
{
    [TargetElement("sc-textarea")]
    public class TextareaTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "textarea";

            output.AppendClass("form-control");

            base.Process(context, output);
        }

        internal static void AppendClass(TagHelperOutput output, string cssClass)
        {

            if (output.Attributes["class"] == null)
            {
                output.Attributes["class"] = string.Empty;
            }
            output.Attributes["class"].Value += " " + cssClass;
        }
    }
}
