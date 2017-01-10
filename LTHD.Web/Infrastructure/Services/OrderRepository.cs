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
    public class OrderRepository : IOrderRepository
    {
        LTHD_DbContext context = new LTHD_DbContext();
        public IQueryable<Order> All
        {
            get { return context.Orders; }
        }

        public Order Find(int Id)
        {
            return context.Orders.Find(Id);
        }

        public async Task<int> InsertOrUpdate(Order entity)
        {
            if (entity.OrderId == default(int))
            {
                context.Orders.Add(entity);
            }
            else
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            return await context.SaveChangesAsync();
        }

        public async Task<Order> Delete(int id)
        {
            var action = context.Orders.Find(id);
            if (action != null)
            {
                context.Orders.Remove(action);
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
