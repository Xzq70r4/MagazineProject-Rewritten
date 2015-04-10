using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineProject.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MagazineProject.Data.Common.Model;

    public class ThumbnailPostCoverImage : Image
    {
        [Key, ForeignKey("Post")]
        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
