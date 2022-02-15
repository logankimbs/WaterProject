﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WaterProject.Models.ViewModels;

namespace WaterProject.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-blah")]
    public class Pagination : TagHelper
    {
        private IUrlHelperFactory Uhf;

        public Pagination(IUrlHelperFactory uhf)
        {
            Uhf = uhf;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext Vc { get; set; }
        public PageInformation PageBlah { get; set; }
        public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper uh = Uhf.GetUrlHelper(Vc);
            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i < PageBlah.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["Href"] = uh.Action(PageAction, new { PageNum = i });
                tb.InnerHtml.Append(i.ToString());
                final.InnerHtml.AppendHtml(tb);
            }

            output.Content.AppendHtml(final.InnerHtml);
        }
    }
}
