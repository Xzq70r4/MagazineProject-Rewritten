﻿namespace MagazineProject.Web.Infrastructure.Populators
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public interface IDropDownListPopulator
    {
        IEnumerable<SelectListItem> GetCategories();

        IEnumerable<SelectListItem> GetSelectedCategories();

        IEnumerable<SelectListItem> GetRoles();
    }
}
