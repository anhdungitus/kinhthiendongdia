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
    public class OrderLineRepository : IOrderLineRepository
    {
        LTHD_DbContext context = new LTHD_DbContext();
        public IQueryable<OrderLine> All
        {
            get { return context.OrderLines; }
        }

        public OrderLine Find(int Id)
        {
            return context.OrderLines.Find(Id);
        }

        public async Task<int> InsertOrUpdate(OrderLine entity)
        {
            if (entity.OrderLineId == default(int))
            {
                context.OrderLines.Add(entity);
            }
            else
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            return await context.SaveChangesAsync();
        }

        public async Task<OrderLine> Delete(int id)
        {
            var action = context.OrderLines.Find(id);
            if (action != null)
            {
                context.OrderLines.Remove(action);
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
