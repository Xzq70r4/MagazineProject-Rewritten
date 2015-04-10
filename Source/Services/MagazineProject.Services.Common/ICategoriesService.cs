using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagazineProject.Data.Models;

namespace MagazineProject.Services.Common.Data
{
    public interface ICategoriesService
    {
        IQueryable<Category> GetCategories();
    }
}
