namespace MagazineProject.Services.Moderator
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common;
    using MagazineProject.Services.Common.Moderator;
    using MagazineProject.Web.Models.Area.Moderator.InputViewModels;
    using MagazineProject.Web.Models.Area.Moderator.InputViewModels.Post;
    using MagazineProject.Web.Models.InputModels.Base;
    using MagazineProject.Web.Models.InputModels.Base.Post;

    public class AdministationPostsService : BaseAdministrationPostsService, IAdministrationPostsService
    {
        public AdministationPostsService(IUnitOfWorkData data)
            : base(data)
        {
        }

        public IQueryable<Post> GetPostsForGrid()
        {
            return base.GetPostsForGrid();
        }
        public IQueryable<Post> GetPostById(int postId)
        {
            return base.GetPostById(postId);
        }
        public void AddDbPost(BaseAdministrationPostsViewModels viewModel, string userId)
        {
            base.AddDbPost(viewModel,userId);
        }

        public void Edit(Post post, BaseAdministrationPostsViewModels viewModel)
        {
            base.Edit(post,viewModel);
        }
    }
}