namespace MagazineProject.Web.Models.Base
{
    using System;

    public class BaseCommentViewModel
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public string AuthorId { get; set; }

        public string Content { get; set; }

        public DateTime TimeCreated { get; set; }
    }
}