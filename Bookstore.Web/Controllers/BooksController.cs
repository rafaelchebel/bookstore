using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Service.Interfaces;
using Bookstore.Model;

namespace Bookstore.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        // GET: Books
        public ActionResult Index()
        {
            return View(this._bookService.GetAll().OrderBy(b => b.Title));
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    book.Id = Guid.NewGuid();
                    this._bookService.Add(book);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

        // GET: Books/Edit/5
        public ActionResult Edit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid bookId = Guid.Parse(id);
                var book = this._bookService.FindByID(bookId);
                if (book != null)
                    return View(book);
            }

            return View();
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Guid bookId = Guid.Parse(id);
                    this._bookService.Update(bookId, book);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

        // GET: Books/Delete/5
        public ActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid bookId = Guid.Parse(id);
                var book = this._bookService.FindByID(bookId);
                if (book != null)
                    return View(book);
            }

            return View();
        }

        // POST: Books/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Book book)
        {
            try
            {
                Guid bookId = Guid.Parse(id);
                this._bookService.Remove(bookId);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}