using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Infrastruckte.TagHalpers
{
    [HtmlTargetElement("table")]   // tag  helper  html için kullanıldığı için bu mecburi
    public class TableTagHelper :TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class","table table-hover  table-bordered");
        }

    }
}
