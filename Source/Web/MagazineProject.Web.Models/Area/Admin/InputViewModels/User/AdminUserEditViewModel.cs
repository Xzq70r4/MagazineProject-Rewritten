namespace MagazineProject.Web.Models.Area.Admin.InputViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    using MagazineProject.Web.Models.InputModels.Base.User;

    public class AdminUserEditViewModel : BaseUserEditViewModel
    {
        public string Id { get; set; }

        [MinLength(3)]
        [MaxLength(15)]
        [Display(Name = "UserName")]
        [UIHint("SingleLineText")]
        public string UserName { get; set; }
    }
}
