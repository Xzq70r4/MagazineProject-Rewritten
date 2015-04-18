namespace MagazineProject.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using MagazineProject.Data.Common;
    using MagazineProject.Data.Common.Model;

    public class Comment : AuditInfo
    {
        public Comment()
        {
            //default value
            Status = Status.Published;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(25000)]
        [DataType(DataType.Html)]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [DefaultValue(Status.Published)]
        public Status Status { get; set; }

        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}