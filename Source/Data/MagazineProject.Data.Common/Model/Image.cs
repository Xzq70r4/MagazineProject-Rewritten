namespace MagazineProject.Data.Common.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Required]
        public byte[] Content { get; set; }

        [Required]
        public string FileExtension { get; set; }
    }
}
