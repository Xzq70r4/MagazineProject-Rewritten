namespace MagazineProject.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MagazineProject.Data.Common.Model;

    public class PostImage : Image
    {
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
