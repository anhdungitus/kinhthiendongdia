using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTHD.Infrastructure.Interfaces;
using LTHD.DataModel;
using LTHD.Domain.Models;
using System.Data.Entity;

namespace LTHD.Infrastructure.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        LTHD_DbContext context = new LTHD_DbContext();
        public IQueryable<Category> All
        {
            get { return context.Categories; }
        }

        public Category Find(int Id)
        {
            return context.Categories.Find(Id);
        }

        public async Task<int> InsertOrUpdate(Category entity)
        {
            if (entity.CategoryId == default(int))
            {
                context.Categories.Add(entity);
            }
            else
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            return await context.SaveChangesAsync();
        }

        public async Task<Category> Delete(int id)
        {
            var action = context.Categories.Find(id);
            if (action != null)
            {
                context.Categories.Remove(action);    
            }
            await context.SaveChangesAsync();
            return action;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.SaveChanges();
            context.Dispose();
        }

    }
}
