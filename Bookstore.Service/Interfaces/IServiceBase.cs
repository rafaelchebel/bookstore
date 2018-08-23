using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Service.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity item);
        bool Remove(int id);
        TEntity Update(TEntity item);
        TEntity FindByID(int id);
        TEntity FindByID(int id, int compositeId);
        TEntity FindByID(int id, int compositeId, int sortId);
        TEntity FindByID(int id, int compositeId, int sortId, int sort);
        IEnumerable<TEntity> GetAll();
    }
}
