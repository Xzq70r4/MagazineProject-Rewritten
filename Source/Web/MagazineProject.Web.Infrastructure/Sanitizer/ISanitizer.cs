namespace MagazineProject.Web.Infrastructure.Sanitizer
{
    public interface ISanitizer
    {
        string Sanitize(string html);
    }
}