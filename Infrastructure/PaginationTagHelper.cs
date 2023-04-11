using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntexScratch.Models.ViewModels;

namespace IntexScratch.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")] //asp-action is the attribute for the a tags, this is a custom attribute
    public class PaginationTagHelper : TagHelper
    {
        //Dynamically create the page links

        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        public PageInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public string PageClass { get; set; }
        public bool PageClassesEnabled { get; set; }

        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            int startPage = Math.Max(1, PageModel.CurrentPage - MaxPagesToShow / 2);
            int endPage = Math.Min(PageModel.TotalPages, startPage + MaxPagesToShow - 1);

            if (startPage > 1)
            {
                TagBuilder tbFirst = GeneratePageLink(uh, 1, "<<");
                final.InnerHtml.AppendHtml(tbFirst);
                if (startPage > 2)
                {
                    TagBuilder tbEllipsis = GenerateEllipsis();
                    final.InnerHtml.AppendHtml(tbEllipsis);
                }
            }

            for (int i = startPage; i <= endPage; i++)
            {
                TagBuilder tb = GeneratePageLink(uh, i);
                final.InnerHtml.AppendHtml(tb);
            }

            if (endPage < PageModel.TotalPages)
            {
                if (endPage < PageModel.TotalPages - 1)
                {
                    TagBuilder tbEllipsis = GenerateEllipsis();
                    final.InnerHtml.AppendHtml(tbEllipsis);
                }
                TagBuilder tbLast = GeneratePageLink(uh, PageModel.TotalPages, ">>");
                final.InnerHtml.AppendHtml(tbLast);
            }

            tho.Content.AppendHtml(final.InnerHtml);
        }

        private const int MaxPagesToShow = 5;

        private TagBuilder GeneratePageLink(IUrlHelper uh, int pageNumber, string text = null)
        {
            TagBuilder tb = new TagBuilder("a");

            tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = pageNumber });

            if (PageClassesEnabled)
            {
                tb.AddCssClass(PageClass);
                tb.AddCssClass(pageNumber == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
            }

            tb.InnerHtml.AppendHtml(text ?? pageNumber.ToString());

            return tb;
        }

        private TagBuilder GenerateEllipsis()
        {
            TagBuilder tb = new TagBuilder("span");

            tb.InnerHtml.Append("");

            return tb;
        }

    }
}
