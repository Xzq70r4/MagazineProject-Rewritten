namespace MagazineProject.Web.Infrastructure.HtmlHelpers
{
    using System.IO;
    using System.Web.Mvc;

    using HtmlTags;

    public static class Buttons
    {
        public static HtmlTag Submit(this HtmlHelper helper, string value)
        {
            return new HtmlTag("input")
                .Attr("type", "submit")
                .Attr("value", value)
                .Attr("class", "btn btn-primary");
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string src, string alt, string cssclass)
        {
            var builder = new TagBuilder("img");
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            if (!File.Exists(helper.ViewContext.HttpContext.Server.MapPath(src)))
                src = urlHelper.Content("~/Images/default-user-img.jpg");
            else
                src = urlHelper.Content(src);

            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", alt);
            builder.MergeAttribute("class", cssclass);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}
