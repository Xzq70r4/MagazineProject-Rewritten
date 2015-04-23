namespace MagazineProject.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using MagazineProject.Data.Common;
    using MagazineProject.Data.Migrations;
    using MagazineProject.Data.Models;

    public class MagazineProjectDbContext : IdentityDbContext<User>
    {
        public MagazineProjectDbContext()
            : base("DefaultConnection", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MagazineProjectDbContext, Configuration>());
        }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<UserImage> UserImages { get; set; }

        public virtual IDbSet<ThumbnailPostCoverImage> ThumbnailPostCoverImages { get; set; }

        public virtual IDbSet<SliderPostCoverImage> SliderPostCoverImages { get; set; }

        public virtual IDbSet<SiteConstant> SiteConstants { get; set; }




        public static MagazineProjectDbContext Create()
        {
            return new MagazineProjectDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                ChangeTracker.Entries()
                    .Where(
                        e =>
                            e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))

            {
                var entity = (IAuditInfo) entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}