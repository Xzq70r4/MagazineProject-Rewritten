namespace MagazineProject.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using MagazineProject.Common;
    using MagazineProject.Data.Common.Model;
    using MagazineProject.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MagazineProjectDbContext>
    {
        private readonly IRandomGenerator random;
        private UserManager<User> userManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            //TODO: false for producion
            this.AutomaticMigrationDataLossAllowed = true;
            this.random = new RandomGenerator();
        }

        protected override void Seed(MagazineProjectDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            this.userManager = new UserManager<User>(new UserStore<User>(context));

            this.SeedRoles(context);
            this.SeedSiteConstants(context);

            this.SeedUsers(context, GlobalConstants.Admin);
            this.SeedUsers(context, GlobalConstants.Moderator);
            this.SeedUsers(context, GlobalConstants.Writer);
            this.SeedUsers(context, GlobalConstants.User);

            var categories = this.SeedCategories(context);
            this.SeedPosts(context, categories);
            this.SeedPostImages(context);

            this.SeedComments(context);
        }

        private void SeedRoles(MagazineProjectDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.Admin));
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.Writer));
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.Moderator));

            context.SaveChanges();
        }

        private void SeedUsers(MagazineProjectDbContext context, string role)
        {
            //for (var i = 0; i <= 100; i++)
            for (var i = 0; i <= 10; i++)
            {
                if (i == 0)
                {
                    var firsUser = new User
                    {
                        Email = string.Format("{0}@email.com", role),
                        UserName = string.Format("{0}", role),
                        FirstName = this.random.RandomString(4, 14),
                        LastName = this.random.RandomString(4, 14),
                        InfoContent = this.random.RandomString(51, 999),
                        UserImage = new UserImage
                        {
                            Content = this.ConvertImageToBytes(GlobalConstants.UserImagePath),
                            FileExtension = "jpg"
                        }
                    };

                    if (role != GlobalConstants.User)
                    {
                        this.userManager.Create(firsUser, GlobalConstants.DefaultPassword);
                        this.userManager.AddToRole(firsUser.Id, role);
                    }
                    else
                    {
                        this.userManager.Create(firsUser, GlobalConstants.DefaultPassword);
                    }
                }
                else
                {
                    var user = new User
                    {
                        Email = string.Format("{0}{1}@email.com", role, i),
                        UserName = string.Format("{0}{1}", role, i),
                        FirstName = this.random.RandomString(4, 14),
                        LastName = this.random.RandomString(4, 14),
                        InfoContent = this.random.RandomString(51, 999),
                        UserImage = new UserImage
                        {
                            Content = this.ConvertImageToBytes(GlobalConstants.UserImagePath),
                            FileExtension = "jpg"
                        }
                    };

                    if (role != GlobalConstants.User)
                    {
                        this.userManager.Create(user, GlobalConstants.DefaultPassword);
                        this.userManager.AddToRole(user.Id, role);
                    }
                    else
                    {
                        this.userManager.Create(user, GlobalConstants.DefaultPassword);
                    }
                }
            }
        }

        private IList<Category> SeedCategories(MagazineProjectDbContext context)
        {
            var categories = new List<Category>();
            var categoryNames = new List<string>
            {
                "LIFESTYLE", "WEB&SOFT", "SOCIAL", "BUSINESS", "MOTIVATION"
            };

            foreach (var categoryName in categoryNames)
            {
                var category = new Category { Name = categoryName };
                context.Categories.Add(category);
                categories.Add(category);
            }

            context.SaveChanges();

            return categories;
        }

        private void SeedPosts(MagazineProjectDbContext context, IList<Category> categories)
        {
            //TODO: Requeest only for writer
            var users = context
                .Users
                .Where(u => u.UserName.StartsWith("Wrtiter") ||
                    u.UserName.StartsWith("Moderator") ||
                    u.UserName.StartsWith("Admin"))
                .Take(10)
                .ToList();
            //var users = context.Users.Take(80).ToList();
            //for (int i = 0; i < 500; i++)
            for (int i = 0; i < 30; i++)
            {
                var post = new Post
                {
                    Title = this.random.RandomString(11, 149),
                    Content = this.random.RandomString(1600, 25000),
                    AuthorId = users[this.random.RandomNumber(0, users.Count - 1)].Id,
                    UrlVideo = this.GetVideoUrl(),
                    CategoryId = categories[this.random.RandomNumber(0, categories.Count - 1)].Id,
                    Status = Status.Published
                };

                context.Posts.Add(post);
            }

            context.SaveChanges();
        }

        private void SeedPostImages(MagazineProjectDbContext context)
        {
            var posts = context.Posts.ToList();

            foreach (var post in posts)
            {
                post.SliderCoverImage = new SliderPostCoverImage
                {
                    Content =
                        this.ConvertImageToBytes(
                            GlobalConstants.SliderPostCoverImagePath),
                    FileExtension = "jpg",
                    PostId = post.Id
                };

                post.ThumbnailCoverImage = new ThumbnailPostCoverImage
                {
                    Content =
                        this.ConvertImageToBytes(
                            GlobalConstants.ThumbnailPostCoverImagePath),
                    FileExtension = "jpg",
                    PostId = post.Id
                };
            }
        }

        private void SeedComments(MagazineProjectDbContext context)
        {
            var users = context.Users.Take(10).ToList();
            var posts = context.Posts.Take(10).ToList();
            //var users = context.Users.Take(80).ToList();
            //var posts = context.Posts.Take(80).ToList();
            //for (int i = 0; i < 1000; i++)
            for (int i = 0; i < 100; i++)
            {
                var comment = new Comment
                {
                    AuthorId = users[this.random.RandomNumber(0, users.Count - 1)].Id,
                    Content = this.random.RandomString(21, 24000),
                    PostId = posts[this.random.RandomNumber(0, posts.Count - 1)].Id
                };

                context.Comments.Add(comment);
            }

            context.SaveChanges();
        }

        private void SeedSiteConstants(MagazineProjectDbContext context)
        {
            var sliderPost = new SiteConstant
            {
                Value = 5,
                Description = GlobalConstants.SiteConstSlider
            };

            var postWithVideo = new SiteConstant
            {
                Value = 4,
                Description = GlobalConstants.SiteConstVideoPost
            };

            context.SiteConstants.Add(sliderPost);
            context.SiteConstants.Add(postWithVideo);
            context.SaveChanges();
        }

        private string GetVideoUrl()
        {
            var videos = new[]
            {
                "https://www.youtube.com/embed/OMOVFvcNfvE",
                "https://www.youtube.com/embed/wTKb9qw0zds",
                "https://www.youtube.com/embed/8xroGBuT54I",
                "https://www.youtube.com/embed/JuyB7NO0EYY"
            };

            var videoUrl = videos[this.random.RandomNumber(0, videos.Length - 1)];
            return videoUrl;
        }

        private byte[] ConvertImageToBytes(string filePath)
        {
            var directory = AssemblyHelpers.GetDirectoryForAssembyl(Assembly.GetExecutingAssembly());
            var file = File.ReadAllBytes(directory + filePath);

            return file;
        }
    }
}