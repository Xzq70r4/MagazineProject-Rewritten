namespace MagazineProject.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SiteConstant
    {
        public int Id { get; set; }

        [Range(0, 16)]
        public int Value { get; set; }

        public string Description { get; set; }
    }
}
