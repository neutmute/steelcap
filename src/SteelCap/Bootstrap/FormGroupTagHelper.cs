using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SteelCap.Extensions;

namespace SteelCap
{
    [HtmlTargetElement("sc-form-group-label")]
    public class FormGroupLabel : TagHelper
    {
        public bool Horizontal { get; set; }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var originalContent = await output.GetChildContentAsync();
            var labelBuilder = Get(Horizontal, originalContent.GetContent());
            output.TagName = labelBuilder.TagName;

            if (labelBuilder.Attributes.ContainsKey("class"))
            {
                output.Attributes.Add("class", labelBuilder.Attributes["class"]);
            }

            output.Content.SetHtmlContent(labelBuilder.InnerHtml);
        }

        internal static TagBuilder Get(bool isHorizontal, string contentEncoded)
        {
            var labelBuilder = new TagBuilder("label");
            if (isHorizontal)
            {
                labelBuilder.AddCssClass("control-label");
                labelBuilder.AddCssClass("col-sm-4");
            }

            labelBuilder.InnerHtml.AppendHtml(contentEncoded);

            return labelBuilder;
        }
    }

    /*
        <div class="form-group">
        <label >{{LabelText}}</label>
        {{original content}}
        </div>
        */
    [HtmlTargetElement("sc-form-group")]
    public class FormGroup : TagHelper
    {
        public string LabelText { get; set; }

        public bool Horizontal { get; set; }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var originalContent = await output.GetChildContentAsync();

            output.AppendClass("form-group");

            TagBuilder labelBuilder = null;
            if (!originalContent.GetContent().Contains("<label"))
            {
                labelBuilder = FormGroupLabel.Get(Horizontal, LabelText);
            }

            var contentDiv = new TagBuilder("div");

            if (Horizontal)
            {
                contentDiv.AddCssClass("col-sm-8");
            }

            contentDiv.InnerHtml.AppendHtml(originalContent.GetContent());
            
            output.TagName = "div";
            output.Content.Clear();
            if (labelBuilder != null)
            {
                output.Content.AppendHtml(labelBuilder);
            }
            output.Content.AppendHtml(contentDiv);

            base.Process(context, output);
        }
    }
}
