using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace LTHD.Infrastructure.Interfaces
{
    public interface IEntityRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        T Find(int id);
        Task<int> InsertOrUpdate(T entity);
        Task<T> Delete(int id);
        void Save();
    }
}
