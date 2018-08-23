using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Repository.Interfaces
{
    public interface IBookstoreRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity item);
        bool Remove(Guid id);
        TEntity Update(TEntity oldItem, TEntity newItem);
        //TEntity Update(Guid Id, TEntity item);
        TEntity FindByID(Guid id);
        TEntity FindByID(Guid id, int compositeId);
        TEntity FindByID(Guid id, int compositeId, int sortId);
        TEntity FindByID(Guid id, int compositeId, int sortId, int sort);
        IEnumerable<TEntity> GetAll();
    }
}
