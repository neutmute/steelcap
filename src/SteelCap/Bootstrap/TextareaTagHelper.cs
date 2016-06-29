using Microsoft.AspNetCore.Razor.TagHelpers;
using SteelCap.Extensions;

namespace SteelCap.Bootstrap
{
    [HtmlTargetElement("sc-textarea")]
    public class TextareaTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "textarea";

            output.AppendClass("form-control");

            base.Process(context, output);
        }
    }
}
