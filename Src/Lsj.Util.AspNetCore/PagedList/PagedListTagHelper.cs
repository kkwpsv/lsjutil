using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Lsj.Util.HtmlBuilder.Body;
using Lsj.Util.HtmlBuilder;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace Lsj.Util.AspNetCore.PagedList
{
    /// <summary>
    /// PagedList TagHelper
    /// </summary>
    [HtmlTargetElement("pager")]
    public class PagedListTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory UrlHelperFactory;
        private IUrlHelper urlHelper;

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        /// <summary>
        /// PagedList
        /// </summary>
        [HtmlAttributeName("list")]
        public IPagedList List { get; set; }

        /// <summary>
        /// RouteValues
        /// </summary>
        [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix = "asp-route-")]
        public IDictionary<string, string> RouteValues { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);


        /// <summary>
        /// Controller
        /// </summary>
        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        /// <summary>
        /// Action
        /// </summary>
        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }


        /// <summary>
        /// Param Name for Page Number
        /// </summary>
        [HtmlAttributeName("param-page-number")]
        public string ParamNamePageNumber { get; set; } = "page";

        /// <summary>
        /// Render Options
        /// </summary>
        [HtmlAttributeName("options")]
        public PagedListRenderOptions Options { get; set; } = new PagedListRenderOptions();


        public PagedListTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.UrlHelperFactory = urlHelperFactory;
        }



        private string GetPageUrl(int page)
        {
            var routeValues = new RouteValueDictionary();

            foreach (var routeValue in this.RouteValues)
            {
                if (!routeValues.ContainsKey(routeValue.Key.ToLower()))
                {
                    routeValues.Add(routeValue.Key, routeValue.Value);
                }
            }

            if (!routeValues.ContainsKey(this.ParamNamePageNumber))
            {
                routeValues.Add(this.ParamNamePageNumber, page.ToString());
            }

            if (this.Action != null && this.Controller != null)
            {
                return urlHelper.Action(this.Action, this.Controller, routeValues);
            }

            return page.ToString();
        }

        private Li GetLi(int page)
        {
            var li = new Li();
            li.Params.AddClasses(Options.LiClasses);
            var a = new A();
            a.Params["href"] = GetPageUrl(page);
            a.Params.AddClasses(Options.AClasses);
            li.Add(a);
            return li;
        }

        /// <summary>
        /// Process
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            this.urlHelper = this.UrlHelperFactory.GetUrlHelper(this.ViewContext);
            if (this.List == null)
            {
                return;
            }
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            int firstPage = List.PageNumber - Options.MaxPageNumber;
            firstPage = firstPage < 1 ? 1 : firstPage;
            int lastPage = firstPage + Options.MaxPageNumber;
            lastPage = lastPage > List.PageCount ? List.PageCount : lastPage;

            var ul = new Ul();
            if (Options.RenderFirstPage == RenderMode.Always || (Options.RenderFirstPage == RenderMode.IfNeeded && firstPage > 1))
            {
                var first = GetLi(1);
                if (List.PageCount == 1 || List.PageCount == 0)
                {
                    first.Params.AddClasses("disabled");
                }
                first.Children.Single().Add(new HtmlRawNode(Options.LinkToFirstPageText));
                ul.Add(first);
            }

            var previous = GetLi(List.PageNumber - 1);
            if (List.PageNumber - 1 < 1)
            {
                previous.Params.AddClasses("disabled");
            }
            previous.Children.Single().Add(new HtmlRawNode(Options.LinkToPreviousPageText));
            ul.Add(previous);

            for (int i = firstPage; i <= lastPage; i++)
            {
                var page = GetLi(i);
                if (List.PageNumber == i)
                {
                    page.Params.AddClasses("active");
                }
                page.Children.Single().Add(new HtmlRawNode(i.ToString()));
                ul.Add(page);
            }


            var next = GetLi(List.PageNumber + 1);
            if (List.PageNumber + 1 > List.PageCount)
            {
                next.Params.AddClasses("disabled");
            }
            next.Children.Single().Add(new HtmlRawNode(Options.LinkToNextPageText));
            ul.Add(next);

            if (Options.RenderLastPage == RenderMode.Always || (Options.RenderLastPage == RenderMode.IfNeeded && lastPage < List.PageCount))
            {
                var last = GetLi(List.PageCount);
                if (List.PageCount == 1 || List.PageCount == 0)
                {
                    last.Params.AddClasses("disabled");
                }
                last.Children.Single().Add(new HtmlRawNode(Options.LinkToLastPageText));
                ul.Add(last);
            }
            ul.Params.AddClasses(Options.UlClasses);
            output.Content.AppendHtml(ul.ToString());
        }
    }
}
