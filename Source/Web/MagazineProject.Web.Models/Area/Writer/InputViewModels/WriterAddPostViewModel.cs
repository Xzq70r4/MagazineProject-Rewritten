namespace MagazineProject.Web.Models.Area.Writer.InputViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using MagazineProject.Web.Infrastructure.ValidationAttribute;
    using MagazineProject.Web.Models.InputModels.Base.Post;

    public class WriterAddPostViewModel : BaseAutorizationPostViewModel
    {
        //[Required]
        //[Display(Name = "Cover Image")]
        //[UIHint("RequiredUploadImage")]
        //[FileTypes("jpg,jpeg,png")]
        //[FileSize(4194304)]
        //public HttpPostedFileBase UploadedImage { get; set; }
    }
}