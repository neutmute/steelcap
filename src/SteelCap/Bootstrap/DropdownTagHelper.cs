using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using SteelCap;
using SteelCap.Extensions;

namespace SteelCap
{
    [TargetElement("sc-dropdown")]
    public class Dropdown : TagHelper
    {
        public List<SelectListItem> Items { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";

            output.AppendClass("form-control");

            var optionsList = new StringBuilder();

            if (Items == null)
            {
                Items = new List<SelectListItem>();
            }

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
