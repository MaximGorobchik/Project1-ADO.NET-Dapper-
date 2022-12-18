using main.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.Interface
{
    internal interface ICategoriesRepository
    {
        public IEnumerable<Categories> CategoriesModel();
    }
}
