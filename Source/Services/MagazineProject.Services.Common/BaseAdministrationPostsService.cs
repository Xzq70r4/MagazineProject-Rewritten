namespace MagazineProject.Services.Common
{
    using System.Linq;
    using System.Web.Helpers;

    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Web.Models.InputModels.Base.Post;

    public class BaseAdministrationPostsService : BaseAutorizePostsService
    {
        public BaseAdministrationPostsService(IUnitOfWorkData data)
            : base(data)
        {
        }

        public IQueryable<Post> GetPostsForGrid()
        {
            var posts = this.Data
                .Posts
                .All()
                .Where(p => p.Category.IsHidden == false)
                .OrderByDescending(p => p.CreatedOn);

            return posts;
        }

        public IQueryable<Post> GetPostById(int postId)
        {
            var post = this.Data
                .Posts
                .All()
                .Where(p => p.Id == postId && p.Category.IsHidden == false);

            return post;
        }

        public void AddDbPost(BaseAdministrationPostsViewModels viewModel, string userId)
        {
            var dbPost = Mapper.Map<Post>(viewModel);
            dbPost.AuthorId = userId;
            this.Data.Posts.Add(dbPost);
            this.Data.SaveChanges();

            var savedPost = this.Data.Posts.GetById(dbPost.Id);
            savedPost.SliderCoverImage = new SliderPostCoverImage();
            savedPost.ThumbnailCoverImage = new ThumbnailPostCoverImage();

            var image = WebImage.GetImageFromRequest();
            var sliderImage = image.Clone();
            var thumbnailImage = image.Clone();

            base.UpdatedSliderPostCoverImage(savedPost, viewModel, sliderImage);
            base.UpdatedThumbnailPostCoverImage(savedPost, viewModel, thumbnailImage);

            savedPost.Status = viewModel.Status;

            this.Data.Posts.Update(savedPost);
            this.Data.SaveChanges();
        }

        public void Edit(Post post, BaseAdministrationPostsViewModels viewModel)
        {
            post.Title = viewModel.Title;
            post.Content = viewModel.Content;
            post.CategoryId = viewModel.CategoryId;

            var image = WebImage.GetImageFromRequest();
            if (image != null)
            {
                var sliderImage = image.Clone();
                var thumbnailImage = image.Clone();

                base.UpdatedSliderPostCoverImage(post, viewModel, sliderImage);
                base.UpdatedThumbnailPostCoverImage(post, viewModel, thumbnailImage);
            }

            post.Status = viewModel.Status;

            Data.Posts.Update(post);
            Data.SaveChanges();
        }
    }
}
