using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace Steelcap
{
    /*
    
    <div class="form-group">
    <label >{{LabelText}}</label>
    {{original content}}
    </div>
    */
    /// <summary>
    /// 
    /// </summary>
    /// <example>
    /// <sc-form-group label-text="Name"></sc-form-group>
    /// </example>
    [TargetElement("sc-form-group")]
    public class FormGroup : TagHelper
    {
        public string LabelText { get; set; }

        public bool Horizontal { get; set; }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var originalContent = await context.GetChildContentAsync();

            output.TagName = "div";
            output.Attributes["class"] = "form-group";

            var label = new TagBuilder("label");
            label.SetInnerText(LabelText);

            var contentDiv = new TagBuilder("div");

            if (Horizontal)
            {
                label.AddCssClass("control-label");
                label.AddCssClass("col-sm-3");

                contentDiv.AddCssClass("col-sm-9");
            }

            contentDiv.InnerHtml = originalContent.GetContent();
            
            var finalHtml = label.ToHtmlString(TagRenderMode.Normal).ToString()
                            + contentDiv.ToHtmlString(TagRenderMode.Normal).ToString();

            output.Content.SetContent(finalHtml);

            base.Process(context, output);
        }
    }
}
