namespace MagazineProject.Web.Models.InputModels.Base.Post
{
    using System.ComponentModel.DataAnnotations;

    using MagazineProject.Data.Common.Model;

    public class BaseAdministrationPostsViewModels : BaseAutorizationPostViewModel
    {
        [UIHint("Enum")]
        public Status Status { get; set; }
    }
}
