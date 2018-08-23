using Bookstore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Service.Interfaces
{
    public interface IBookService : IBookstoreServiceBase<Book>
    {
        Book Update(Guid Id, Book book);
    }
}
