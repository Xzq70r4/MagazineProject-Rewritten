namespace MagazineProject.Web.Infrastructure.Populators
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Web.Infrastructure.Caching;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class DropDownListPopulator : IDropDownListPopulator
    {
        private IUnitOfWorkData data;
        private ICacheService cache;

        public DropDownListPopulator(IUnitOfWorkData data, ICacheService cache)
        {
            this.data = data;
            this.cache = cache;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            var categories = this.cache.Get<IEnumerable<SelectListItem>>("Categories",
                () =>
                {
                    return this.data.Categories
                       .All()
                       .Select(c => new SelectListItem
                       {
                           Value = c.Id.ToString(),
                           Text = c.Name
                       })
                       .ToList();
                });

            return categories;
        }

        public IEnumerable<SelectListItem> GetRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var allRoles = roleManager.Roles.ToList();
            IList<SelectListItem> roleList = new List<SelectListItem>();

            foreach (var role in allRoles)
            {
                var item = new SelectListItem
                {
                    Value = role.Name,
                    Text = role.Name
                };
                
                roleList.Add(item);
            }

            var roles = this.cache.Get<IEnumerable<SelectListItem>>("Roles",
                () =>
                {
                    return roleList.ToList();
                });

            return roles;
        }
    }
}