using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace SteelCap.Test
{
    public class TestBase
    {
        protected TagHelperOutput GetSimpleTagHelperOutput()
        {
            var output = new TagHelperOutput("a", attributes: new TagHelperAttributeList());
            output.Content.SetContent(string.Empty);

            return output;
        }

        protected TagHelperContext GetSimpleTagHelperContext()
        {
            var context = new TagHelperContext(
              allAttributes: new ReadOnlyTagHelperAttributeList<IReadOnlyTagHelperAttribute>(
                  Enumerable.Empty<IReadOnlyTagHelperAttribute>()),
              items: new Dictionary<object, object>(),
              uniqueId: "test",
              getChildContentAsync: useCachedResult =>
              {
                  var tagHelperContent = new DefaultTagHelperContent();
                  tagHelperContent.SetContent("Something");
                  return Task.FromResult<TagHelperContent>(tagHelperContent);
              });

            return context;
        }
    }
}
