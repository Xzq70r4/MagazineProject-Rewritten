namespace MagazineProject.Web.Infrastructure.Sanitizer
{
    using Ganss.XSS;

    public class HtmlSanitazerAdapter : ISanitizer
    {
        public string Sanitize(string html)
        {
            var sanitizer = new HtmlSanitizer();
            var result = sanitizer.Sanitize(html);

            return result;
        }
    }
}
