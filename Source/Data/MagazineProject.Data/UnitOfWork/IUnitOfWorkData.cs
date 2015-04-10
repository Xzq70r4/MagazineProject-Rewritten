namespace MagazineProject.Data.UnitOfWork
{
    using System;
    using System.Data.Entity;
    using MagazineProject.Data.Models;
    using MagazineProject.Data.Repository;

    public interface IUnitOfWorkData
    {
        DbContext Context { get; }

        IRepository<User> Users { get; }

        IRepository<Post> Posts { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Category> Categories { get; }

        IRepository<ThumbnailPostCoverImage> ThumbnailPostCoverImages { get; }

        IRepository<SliderPostCoverImage> SliderPostCoverImages { get; }


        IRepository<UserImage> UserImages { get; }
        
        int SaveChanges();
    }
}