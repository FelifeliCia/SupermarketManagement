using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    //类别内存仓库
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;

        public CategoryInMemoryRepository()
        {
            //添加默认类型
            categories = new List<Category>
            {
                new Category
                {
                    CategoryID=1,
                    Name   = "面包",
                    Description="面包的大类别"
                },
            new Category
            {
                CategoryID = 2,
                Name = "蛋糕",
                Description = "蛋糕的大类别"
            },
            new Category
            {
                CategoryID = 3,
                Name = "肉类",
                Description = "肉肉的大类别"
            }
            };
        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (categories != null && categories.Count > 0)
            {
                var maxID = categories.Max(x => x.CategoryID);
                category.CategoryID = maxID + 1;
            }
            else
            {
                category.CategoryID = 1;
            }
            categories.Add(category);
        }

        public void DeleteCategory(int categoryID)
        {
            categories?.Remove(GetCategory(categoryID));
        }

        public IEnumerable<Category> GetCategories()
        {

            return this.categories;
        }

        public Category GetCategory(int id)
        {
            return categories?.FirstOrDefault(x => x.CategoryID == id);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategory(category.CategoryID);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }

        }


    }
}
