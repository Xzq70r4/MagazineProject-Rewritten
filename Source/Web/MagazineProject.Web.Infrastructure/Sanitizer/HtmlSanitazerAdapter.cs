using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ganss.XSS;

namespace MagazineProject.Web.Infrastructure.Sanitizer
{
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
