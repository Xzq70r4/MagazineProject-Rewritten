namespace MagazineProject.Web.Models.InputModels.Base.Post
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using MagazineProject.Web.Infrastructure.ValidationAttribute;

    //Administration is common for Moderator and Admin
    public class BaseAdministrationEditPostViewModel : BaseAdministrationPostsViewModels
    {
        [Display(Name = "Cover Image")]
        [UIHint("UploadImage")]
        [FileTypes("jpg,jpeg,png")]
        [FileSize(4194304)]
        public HttpPostedFileBase UploadedImage { get; set; }
    }
}
