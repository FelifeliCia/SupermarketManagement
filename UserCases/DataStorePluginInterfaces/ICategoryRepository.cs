using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    //类别仓库
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetCategories();
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public Category GetCategory(int id);
        public void DeleteCategory(int categoryID);
    }
}
