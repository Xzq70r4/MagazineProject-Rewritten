namespace MagazineProject.Web.Models.InputModels.Base.Post
{
    using System.ComponentModel.DataAnnotations;

    using MagazineProject.Data.Common.Model;

    //Administration is common for Moderator and Admin
    public class BaseAdministrationPostsViewModels : BaseAutorizationPostViewModel
    {
        [UIHint("Enum")]
        public Status Status { get; set; }
    }
}
