using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.AspNet.Razor.TagHelpers;
using SteelCap.Extensions;

namespace SteelCap
{
    /// <summary>
    /// Need to be able to reference the inner 'main' so return as a pair
    /// </summary>
    internal class WidgetBodyContainer
    {
        public TagBuilder WidgetBody { get; set; }

        public TagBuilder WidgetMain { get; set; }
    }

    /// <summary>
    /// Allow more control over how the Body renders
    /// </summary>
    [HtmlTargetElement(WidgetBoxBodyElement)]
    public class WidgetBoxBodyHelper : TagHelper
    {
        const string WidgetBoxBodyElement = "sc-widget-box-body";

        public bool Padding { get; set; }

        public WidgetBoxBodyHelper()
        {
            Padding = true;
        }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.SuppressOutput();
           
            var originalContent = await output.GetChildContentAsync();

            var bodyContainer = GetBodyContainer(Padding);

            bodyContainer.WidgetMain.InnerHtml.AppendHtml(originalContent.GetContent());

            output.Content.Clear();
            output.Content.Append(bodyContainer.WidgetBody);

            base.Process(context, output);
        }

        private static WidgetBodyContainer GetBodyContainer(bool withPadding)
        {
            var bodyDiv = new TagBuilder("div");
            bodyDiv.AddCssClass("widget-body");
            
            var widgetMain = new TagBuilder("div");
            widgetMain.AddCssClass("widget-main");
            
            if (!withPadding)
            {
                widgetMain.AddCssClass("no-padding");
            }

            bodyDiv.InnerHtml.Append(widgetMain);

            var output = new WidgetBodyContainer();
            output.WidgetBody = bodyDiv;
            output.WidgetMain = widgetMain;

            return output;
        }

        internal static TagBuilder GetFullBodyInternals(bool withPadding, string innerHtml)
        {
            var container = GetBodyContainer(withPadding);

            container.WidgetMain.InnerHtml.AppendHtml(innerHtml);
            
            return container.WidgetBody;
        }

    }
}
