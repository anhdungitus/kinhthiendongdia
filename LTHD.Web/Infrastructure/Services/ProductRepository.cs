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
    public class ProductRepository : IProductRepository
    {
        LTHD_DbContext context = new LTHD_DbContext();
        public IQueryable<Product> All
        {
            get { return context.Products; }
        }

        public Product Find(int Id)
        {
            return context.Products.Find(Id);
        }

        public async Task<int> InsertOrUpdate(Product entity)
        {
            if (entity.ProductId == default(int))
            {
                context.Products.Add(entity);
            }
            else
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            return await context.SaveChangesAsync();
        }

        public async Task<Product> Delete(int id)
        {
            var action = context.Products.Find(id);
            if (action != null)
            {
                context.Products.Remove(action);    
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
