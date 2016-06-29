using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SteelCap.Test
{
    public class TestBase
    {
        protected TagHelperOutput GetSimpleTagHelperOutput()
        {
            var output = new TagHelperOutput("a", new TagHelperAttributeList(), (useCachedResult, encoder) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                tagHelperContent.SetContent("Something");
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });

            output.Content.SetContent(string.Empty);

            return output;
        }

        protected TagHelperContext GetSimpleTagHelperContext()
        {
            var context = new TagHelperContext(
              allAttributes: new TagHelperAttributeList(), 
              items: new Dictionary<object, object>(),
              uniqueId: "test");

            return context;
        }
    }
}
