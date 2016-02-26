using Microsoft.AspNet.Razor.TagHelpers;
using SteelCap.Extensions;

namespace SteelCap
{
    [HtmlTargetElement("sc-checkbox")]
    public class Checkbox : TextboxCore
    {
        protected override string TextBoxType => "checkbox";
    }

    [HtmlTargetElement("sc-emailbox")]
    public class EmailBox : TextboxCore
    {
        protected override string TextBoxType => "email";
    }

    [HtmlTargetElement("sc-numberbox")]
    public class Numberbox : TextboxCore
    {
        protected override string TextBoxType => "number";
    }

    [HtmlTargetElement("sc-textbox")]
    public class Textbox : TextboxCore
    {
        protected override string TextBoxType => "text";
    }

    public abstract class TextboxCore : TagHelper
    {
        public string @Class { get; set; }

        protected abstract string TextBoxType { get; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";

            output.AppendClass(Class);
            output.AppendClass("form-control");
            output.Attributes.Add("type", TextBoxType);

            base.Process(context, output);
        }
    }
}
