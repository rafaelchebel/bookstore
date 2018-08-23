using Bookstore.Repository.Interfaces;
using Bookstore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Service
{
    public class ServiceBase<T> : IDisposable, IBookstoreServiceBase<T> where T : class
    {
        protected IBookstoreRepositoryBase<T> _repository;

        public ServiceBase(IBookstoreRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public bool Remove(Guid id)
        {
            return _repository.Remove(id);
        }

        public T FindByID(Guid id)
        {
            return _repository.FindByID(id);
        }

        public T FindByID(Guid id, int compositeId)
        {
            return _repository.FindByID(id, compositeId);
        }

        public T FindByID(Guid id, int compositeId, int sortId)
        {
            return _repository.FindByID(id, compositeId, sortId);
        }

        public T FindByID(Guid id, int compositeId, int sortId, int sort)
        {
            return _repository.FindByID(id, compositeId, sortId, sort);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T Add(T item)
        {
            return _repository.Add(item);
        }

        public T Update(T oldItem, T newItem)
        {
            return _repository.Update(oldItem, newItem);
        }

        //public T Update(Guid Id, T item)
        //{
        //    return _repository.Update(Id, item);
        //}

        public virtual void Dispose()
        {
            _repository = null;
        }
    }
}
