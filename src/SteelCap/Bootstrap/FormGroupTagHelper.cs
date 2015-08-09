using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace SteelCap
{
    [TargetElement("sc-form-group-label")]
    public class FormGroupLabel : TagHelper
    {
        public bool Horizontal { get; set; }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var originalContent = await context.GetChildContentAsync();
            var labelBuilder = Get(Horizontal, originalContent.GetContent());
            output.TagName = labelBuilder.TagName;

            if (labelBuilder.Attributes.ContainsKey("class"))
            {
                output.Attributes.Add("class", labelBuilder.Attributes["class"]);
            }

            output.Content.SetContent(labelBuilder.InnerHtml);
        }

        internal static TagBuilder Get(bool isHorizontal, string content)
        {
            var labelBuilder = new TagBuilder("label");
            if (isHorizontal)
            {
                labelBuilder.AddCssClass("control-label");
                labelBuilder.AddCssClass("col-sm-4");
            }

            labelBuilder.InnerHtml = content;

            return labelBuilder;
        }
    }

    /*
        <div class="form-group">
        <label >{{LabelText}}</label>
        {{original content}}
        </div>
        */
    [TargetElement("sc-form-group")]
    public class FormGroup : TagHelper
    {
        public string LabelText { get; set; }

        public bool Horizontal { get; set; }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var originalContent = await context.GetChildContentAsync();

            TextboxCore.AppendClass(output, "form-group");

            var labelHtmlString = new HtmlString(string.Empty);
            if (!originalContent.GetContent().Contains("<label"))
            {
                var labelBuilder = FormGroupLabel.Get(Horizontal, LabelText);
                labelHtmlString = labelBuilder.ToHtmlString(TagRenderMode.Normal);
            }

            var contentDiv = new TagBuilder("div");

            if (Horizontal)
            {
                contentDiv.AddCssClass("col-sm-8");
            }

            contentDiv.InnerHtml = originalContent.GetContent();

            var finalHtml = labelHtmlString.ToString()
                            + contentDiv.ToHtmlString(TagRenderMode.Normal).ToString();

            output.TagName = "div";
            output.Content.SetContent(finalHtml);

            base.Process(context, output);
        }
    }
}
