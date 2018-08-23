using Bookstore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Repository.Interfaces
{
    public interface IBookstoreRepository : IBookstoreRepositoryBase<Book>
    {
        Book Update(Guid Id, Book book);
    }
}
