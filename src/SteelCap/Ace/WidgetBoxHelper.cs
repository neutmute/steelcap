using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.AspNet.Razor.TagHelpers;
using SteelCap.Extensions;

namespace SteelCap
{
    [HtmlTargetElement("sc-widget-box")]
    public class WidgetBoxHelper : TagHelper
    {
        public string Title { get; set; }

        public bool IsCollapsible { get; set; }

        public bool Padding { get; set; }

        public string Class { get; set; }

        public WidgetBoxHelper()
        {
            Padding = true;
        }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            output.AppendClass("widget-box");
            output.AppendClass(Class);
            
            var originalContent = await output.GetChildContentAsync();
            var innerHtml = originalContent.GetContent();

            output.Content.Clear();

            if (!innerHtml.Contains(WidgetBoxHeaderHelper.HeaderCss))
            {
                // user is taking easy/lazy way of declaring the widget box
                output.Content.Append(WidgetBoxHeaderHelper.GetFullHeader(Title, IsCollapsible));
                var widgetBodyDiv = WidgetBoxBodyHelper.GetFullBodyInternals(Padding, innerHtml);
                output.Content.Append(widgetBodyDiv);
            }
            else
            {
                // user is doing the hardwork themselves
                output.Content.AppendHtml(innerHtml);
            }
            
            base.Process(context, output);
        }
    }
}
