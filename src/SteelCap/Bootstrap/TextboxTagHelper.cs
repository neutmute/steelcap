using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using SteelCap.Extensions;

namespace SteelCap
{
    [TargetElement("sc-checkbox")]
    public class Checkbox : TextboxCore
    {
        protected override string TextBoxType => "checkbox";
    }

    [TargetElement("sc-emailbox")]
    public class EmailBox : TextboxCore
    {
        protected override string TextBoxType => "email";
    }

    [TargetElement("sc-numberbox")]
    public class Numberbox : TextboxCore
    {
        protected override string TextBoxType => "number";
    }

    [TargetElement("sc-textbox")]
    public class Textbox : TextboxCore
    {
        protected override string TextBoxType => "text";
    }

    public abstract class TextboxCore : TagHelper
    {
        protected abstract string TextBoxType { get; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";

            output.AppendClass("form-control");
            output.Attributes.Add("type", TextBoxType);

            base.Process(context, output);
        }
    }
}
