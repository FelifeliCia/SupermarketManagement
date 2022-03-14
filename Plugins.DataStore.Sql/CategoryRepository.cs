using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.Sql
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketContext db;

        public CategoryRepository(MarketContext db)
        {
            this.db = db;
        }

        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryID)
        {
            var cat= db.Categories.FirstOrDefault(x => x.CategoryID == categoryID);
            if (cat == null) return;
            db.Categories.Remove(GetCategory(categoryID));
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return db.Categories?.FirstOrDefault(x => x.CategoryID == id);
        }

        public void UpdateCategory(Category category)
        {
            var cat = db.Categories.FirstOrDefault(x => x.CategoryID == category.CategoryID);
            if (cat == null) return;
            cat.Name = category.Name;
            cat.Description = category.Description;
            db.SaveChanges();

        }

    }
}
