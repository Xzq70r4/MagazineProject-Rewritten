namespace MagazineProject.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MagazineProject.Data.Common.Model;

    public class UserImage : Image
    {
        [Key, ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
