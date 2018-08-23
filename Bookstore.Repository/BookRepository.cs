using Bookstore.Model;
using Bookstore.Repository.Data;
using Bookstore.Repository.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookstore.Repository
{
    public class BookRepository : BookstoreRepositoryBase<Book>, IBookstoreRepository
    {
        public BookRepository(BookstoreContext context) : base(context)
        {

        }

        public Book Update(Guid id, Book book)
        {
            this.dbCon.Open();

            var query = @"UPDATE `Book` SET `Author` = @pAuthor, `PublishingHouse` = @pPublishingHouse, `Title` = @pTitle, `YearOfPublishing` = @pYearOfPublishing
                            WHERE `Id` = @pId;
                          SELECT ROW_COUNT();";

            var result = this.dbCon.Query<Book>(query, new { @pAuthor = book.Author, @pPublishingHouse = book.PublishingHouse, @pTitle = book.Title, @pYearOfPublishing = book.YearOfPublishing, @pId = id });

            this.dbCon.Close();

            return result.FirstOrDefault();
        }
    }
}
