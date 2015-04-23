namespace MagazineProject.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.Repository;

    public class UnitOfWorkData : IUnitOfWorkData
    {
        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWorkData()
            : this(new MagazineProjectDbContext())
        {
        }

        public UnitOfWorkData(DbContext context)
        {
            this.context = context;
        }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Post> Posts
        {
            get
            {
                return this.GetRepository<Post>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<ThumbnailPostCoverImage> ThumbnailPostCoverImages
        {
            get
            {
                return this.GetRepository<ThumbnailPostCoverImage>();
            }
        }

        public IRepository<SliderPostCoverImage> SliderPostCoverImages
        {
            get
            {
                return this.GetRepository<SliderPostCoverImage>();
            }
        }

        public IRepository<UserImage> UserImages
        {
            get
            {
                return this.GetRepository<UserImage>();
            }
        }

        public IRepository<SiteConstant> SiteConstants
        {
            get
            {
                return this.GetRepository<SiteConstant>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}