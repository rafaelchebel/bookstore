using Bookstore.Repository.Data;
using Bookstore.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Repository
{
    public class BookstoreRepositoryBase<TEntity> : IBookstoreRepositoryBase<TEntity> where TEntity : class
    {
        protected BookstoreContext _context;
        protected DbSet<TEntity> DbSet;
        protected DbConnection dbCon;

        public BookstoreRepositoryBase(BookstoreContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
            this.dbCon = _context.Database.GetDbConnection();
        }

        public virtual TEntity Add(TEntity item)
        {
            TEntity result = DbSet.Add(item).Entity;

            _context.SaveChanges();

            _context.Entry(result).GetDatabaseValues();

            return result;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual TEntity FindByID(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual bool Remove(Guid id)
        {
            TEntity result = FindByID(id);

            if (result == null)
                return false;

            DbSet.Remove(result);

            return _context.SaveChanges() > 0;
        }

        public virtual TEntity Update(TEntity oldItem, TEntity newItem)
        {
            TEntity Result = DbSet.Update(newItem).Entity;
            _context.SaveChanges();

            //var existingCart = _context.Book.Where(b=>b.Id == Guid.Parse("074c6fcc-9495-411b-ae68-73a724ffbac0"));
            //if (existingCart != null)
            //{
            //    var attachedEntry = _context.Entry(existingCart);
            //    attachedEntry.CurrentValues.SetValues(newItem);

            //    _context.SaveChanges();
            //}

            return null;
        }



        public virtual TEntity FindByID(Guid id, int sortKeyId)
        {
            return DbSet.Find(id, sortKeyId);
        }

        public virtual TEntity FindByID(Guid id, int compositeId, int sortId)
        {
            return DbSet.Find(id, compositeId, sortId);
        }

        public virtual TEntity FindByID(Guid id, int compositeId, int sortId, int sort)
        {
            return DbSet.Find(id, compositeId, sortId, sort);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
