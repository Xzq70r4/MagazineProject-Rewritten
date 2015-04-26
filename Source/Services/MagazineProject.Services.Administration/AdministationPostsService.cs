namespace MagazineProject.Services.Moderator
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common.Base;
    using MagazineProject.Services.Common.Moderator;
    using MagazineProject.Web.Models.InputModels.Base.Post;

    //Common for Moderator and Admin Service
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
            base.AddDbPost(viewModel, userId);
        }

        public void Edit(Post post, BaseAdministrationPostsViewModels viewModel)
        {
            base.Edit(post, viewModel);
        }
    }
}