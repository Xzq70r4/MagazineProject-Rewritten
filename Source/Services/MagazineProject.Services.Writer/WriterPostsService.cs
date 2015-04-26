namespace MagazineProject.Services.Writer
{
    using System.Linq;
    using System.Web.Helpers;

    using AutoMapper;

    using MagazineProject.Data.Common.Model;
    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common.Base;
    using MagazineProject.Services.Common.Writer;
    using MagazineProject.Web.Infrastructure.Sanitizer;
    using MagazineProject.Web.Models.Area.Writer.InputViewModels;

    public class WriterPostsService : BaseAutorizePostsService, IWriterPostsService
    {
        private readonly ISanitizer sanitizer;

        public WriterPostsService(IUnitOfWorkData data, ISanitizer sanitizer)
            : base(data)
        {
            this.sanitizer = sanitizer;
        }

        public IQueryable<Post> GetPostsForGrid(string userId)
        {
            var post = this.Data
                .Posts
                .All()
                .Where(p => p.AuthorId == userId && 
                            p.Category.IsHidden == false)
                .OrderByDescending(p => p.CreatedOn);

            return post;
        }

        public IQueryable<Post> GetPostById(int postId)
        {
            var post = this.Data
                .Posts
                .All()
                .Where(p => p.Id == postId &&
                            p.Category.IsHidden == false);

            return post;
        }

        public void AddDbPost(WriterAddPostViewModel viewModel, string userId)
        {
            viewModel.Content = this.sanitizer.Sanitize(viewModel.Content);

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

            this.Data.Posts.Update(savedPost);
            this.Data.SaveChanges();
        }

        public void Edit(Post post, WriterEditPostViewModel viewModel)
        {
            post.Title = viewModel.Title;
            post.Content = this.sanitizer.Sanitize(viewModel.Content);
            post.CategoryId = viewModel.CategoryId;

            var image = WebImage.GetImageFromRequest();
            if (image != null)
            {
                var sliderImage = image.Clone();
                var thumbnailImage = image.Clone();

                base.UpdatedSliderPostCoverImage(post, viewModel, sliderImage);
                base.UpdatedThumbnailPostCoverImage(post, viewModel, thumbnailImage);
            }

            post.Status = Status.EditedWaitingAppoval;

            Data.Posts.Update(post);
            Data.SaveChanges();
        }
    }
}
