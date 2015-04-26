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
    }
}
