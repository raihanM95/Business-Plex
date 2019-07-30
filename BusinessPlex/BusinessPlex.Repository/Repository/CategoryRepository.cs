using BusinessPlex.DatabaseContext.DatabaseContext;
using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.Repository.Repository
{
    public class CategoryRepository
    {
        BusinessPlexDbContext db = new BusinessPlexDbContext();
        public bool AddCategory(Category category)
        {
            int isExecuted = 0;

            db.Categories.Add(category);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteCategory(Category category)
        {
            int isExecuted = 0;

            Category aCategory = db.Categories.FirstOrDefault(c => c.ID == category.ID);

            db.Categories.Remove(aCategory);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool UpdateCategory(Category category)
        {
            int isExecuted = 0;
            
            db.Entry(category).State = EntityState.Modified;
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public Category GetByID(Category category)
        {
            Category aCategory = db.Categories.FirstOrDefault(c => c.ID == category.ID);

            return aCategory;
        }
    }
}
