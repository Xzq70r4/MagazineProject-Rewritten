namespace MagazineProject.Web.Models.InputModels.Base.Post
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using MagazineProject.Web.Infrastructure.ValidationAttribute;

    public class BaseAdministrationAddPostViewModel : BaseAdministrationPostsViewModels
    {
        [Required]
        [Display(Name = "Cover Image")]
        [UIHint("RequiredUploadImage")]
        [FileTypes("jpg,jpeg,png")]
        [FileSize(4194304)]
        public HttpPostedFileBase UploadedImage { get; set; }
    }
}
