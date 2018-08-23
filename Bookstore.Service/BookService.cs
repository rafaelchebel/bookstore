using Bookstore.Model;
using Bookstore.Repository;
using Bookstore.Repository.Interfaces;
using Bookstore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Service
{
    public class BookService : ServiceBase<Book>, IBookService
    {
        private readonly IBookstoreRepository _iBookstoreRepository;

        public BookService(IBookstoreRepository bookstoreRepository) : base(bookstoreRepository)
        {
            _iBookstoreRepository = bookstoreRepository;
        }

        public Book Update(Guid Id, Book book)
        {
            return _iBookstoreRepository.Update(Id, book);
        }
    }
}
