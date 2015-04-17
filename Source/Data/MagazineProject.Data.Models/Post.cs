namespace MagazineProject.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.ComponentModel;

    using MagazineProject.Data.Common;
    using MagazineProject.Data.Common.Model;

    public class Post : AuditInfo
    {
        private ICollection<Comment> comments;

        public Post()
        {
            this.comments = new HashSet<Comment>();
            //Default Valie for Status
            this.Status = Status.WaitingApproval;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MinLength(1500)]
        [MaxLength(25000)]
        public string Content { get; set; }

        public string UrlVideo { get; set; }

        //TODO: Check[DefaultValue(Status.WaitingApproval)]
        public Status Status { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual SliderPostCoverImage SliderCoverImage { get; set; }

        public virtual ThumbnailPostCoverImage ThumbnailCoverImage { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}