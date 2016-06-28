using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SteelCap.Extensions;

namespace SteelCap
{
    [HtmlTargetElement("sc-dropdown")]
    public class Dropdown : TagHelper
    {
        public List<SelectListItem> Items { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.AppendClass("form-control");

            var optionsList = new List<TagBuilder>();

            if (Items == null)
            {
                Items = new List<SelectListItem>();
            }

            foreach (var item in Items)
            {
                var option = new TagBuilder("option");
                option.Attributes.Add("value", item.Value);
                option.InnerHtml.Append(item.Text);

                optionsList.Add(option);
            }
            
            optionsList.ForEach(o =>
            {
                output.Content.Append(o);
            });

            base.Process(context, output);
        }
    }
}
