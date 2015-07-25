using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace Steelcap
{
    [TargetElement("sc-dropdown")]
    public class DropdownHelper : TagHelper
    {
        public List<SelectListItem> Items { get; set; }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.Attributes["class"] = "form-control";
            
            var optionsList = new StringBuilder();
            
            foreach (var item in Items)
            {
                var option = new TagBuilder("option");
                option.Attributes.Add("value", item.Value);
                option.SetInnerText(item.Text);

                optionsList.Append(option.ToHtmlString(TagRenderMode.Normal));
            }

            output.SelfClosing = false;
            
            output.Content.SetContent(optionsList.ToString());

            base.Process(context, output);
        }
    }
}
