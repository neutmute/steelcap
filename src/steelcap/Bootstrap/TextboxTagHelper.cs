using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace Steelcap
{
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
        protected abstract string TextBoxType { get;  }

        public string Placeholder { get; set; }

        public bool Horizontal { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes["class"] = "form-control";
            output.Attributes.Add("type", TextBoxType);

            if (!string.IsNullOrEmpty(Placeholder))
            {
                output.Attributes.Add("placeholder", Placeholder);
            }

            base.Process(context, output);
        }
    }
}
