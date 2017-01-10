using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using LTHD.Domain.Models;

using LTHD.Infrastructure.Interfaces;
using LTHD.Infrastructure.Services;

namespace LTHD.Web.Infrastructure
{
    public class CustomResolver : IDependencyResolver, IDependencyScope
    {
        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(IProductRepository))
            {
                return new ProductRepository();
            }
            else if (serviceType == typeof(IOrderRepository))
            {
                return new OrderRepository();
            }
            else if (serviceType == typeof(ICategoryRepository))
            {
                return new CategoryRepository();
            }
            else if (serviceType == typeof(IOrderLineRepository))
            {
                return new OrderLineRepository();
            }
            else
            {
                return null;
            }
            //return serviceType == typeof(IProductRepository)
            //? new ProductRepository() : (serviceType == typeof(IOrderRepository)) 
            //? new OrderRepository() : null;
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }
        public void Dispose()
        {
            // do nothing - not required
        }
    }
}