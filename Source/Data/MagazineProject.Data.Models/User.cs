namespace MagazineProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using MagazineProject.Data.Common;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser, IAuditInfo
    {
        private ICollection<Comment> comments;
        private ICollection<Post> posts;

        public User()
        {
            // This will prevent UserManager.CreateAsync from causing exception
            this.CreatedOn = DateTime.Now;

            this.posts = new HashSet<Post>();
            this.comments = new HashSet<Comment>();
        }

        [Required]
        [DataType(DataType.EmailAddress)]
        public override string Email
        {
            get { return base.Email; }
            set { base.Email = value; }
        }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public override string UserName
        {
            get { return base.UserName; }
            set { base.UserName = value; }
        }

        [MinLength(3)]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [MinLength(3)]
        [MaxLength(15)]
        public string LastName { get; set; }

        [MinLength(50)]
        [MaxLength(1000)]
        [DataType(DataType.Html)]
        public string InfoContent { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual UserImage UserImage { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}