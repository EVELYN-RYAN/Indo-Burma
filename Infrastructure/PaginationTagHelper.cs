using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Indo_Burma.Models.ViewModels;

namespace Indo_Burma.Infrastructure
{
    // inherits everything from the TagHelper class
    //?? -- this is a tag to say "What is this tag going to be used with? body, div, a?
    [HtmlTargetElement("div", Attributes = "page-indicator")]
    public class PaginationTagHelper : TagHelper
    {
        //Dynamically create the page links for us
        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }
        [ViewContext]
        [HtmlAttributeNotBound] //
        public ViewContext vc { get; set; } //holds information about the view we are working with

        // Different than the view context
        public PageInfo PageIndicator { get; set; } // "PageIndicator" in C# is the same as "page-indicator" in HTML
        public string PageAction { get; set; }
        //Book bootstrap button feature
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            //we need the information about the view we will add these tags to
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i <= PageIndicator.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                // uh is the page, we go to the action we labeled "Index" and then pass the looped parameter
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });

                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageIndicator.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }
                // we add to the same tag builder the number of the page for the value in the tag
                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);

                // My code to add a nbsp between each number
                final.InnerHtml.AppendHtml("&nbsp&nbsp");

            }
            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}
