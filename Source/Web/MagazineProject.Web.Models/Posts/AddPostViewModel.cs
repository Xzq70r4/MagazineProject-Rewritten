namespace MagazineProject.Web.Models.Posts
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;

    public class AddPostViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public string CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}