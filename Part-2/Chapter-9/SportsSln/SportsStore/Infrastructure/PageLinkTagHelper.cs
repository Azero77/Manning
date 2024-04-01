
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModels;

namespace SportsStore.Infrastructure
{
    [HtmlTargetElement("div" , Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory) 
        {
            _urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public PageModel? PageModel { get; set; }
        
        public string PageAction { get; set; } = string.Empty;

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new();

        //Css Classes
        public string CssPageSelected { get; set; }
        public string CssPageNormal { get; set; }




        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext is not null && PageModel is not null) 
            {
                IUrlHelper urlhelper = _urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");
                for (int i = 1, l = PageModel.TotalPages; i <= l; i++) 
                {
                    TagBuilder tmp = new TagBuilder("a");
                    PageUrlValues["PageNumber"] = i;
                    tmp.Attributes["href"] = urlhelper.Action(PageAction,PageUrlValues);
                    tmp.InnerHtml.Append(i.ToString());
                    if (CssPageNormal is not null && CssPageNormal is not null) 
                    {

                        tmp.Attributes["class"] = PageModel.CurrentPage == i ? CssPageSelected : CssPageNormal;
                    }
                    result.InnerHtml.AppendHtml(tmp);
                }

                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}
