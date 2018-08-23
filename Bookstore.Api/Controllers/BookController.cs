using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Service.Interfaces;
using Newtonsoft.Json;
using Bookstore.Model;
using Bookstore.Repository.Data;

namespace Bookstore.Api.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        public IActionResult Get()
        {
            var books = this._bookService.GetAll();

            if (books == null || books.Count() == 0)
                return StatusCode(204, new { Message = $"Não há nenhum livro cadastrado!" });

            return Ok(JsonConvert.SerializeObject(books.OrderBy(b => b.Title)));
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Guid bookId = Guid.Parse(id);
            var book = this._bookService.FindByID(bookId);

            if (book == null)
                return StatusCode(204, new { Message = $"Livro não cadastrado!" });

            return Ok(JsonConvert.SerializeObject(book));
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Post([FromBody]Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this._bookService.Add(book);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Message = $"Ocorreu um erro ao tentar adicionar o livro.\n\nErro: {ex.GetBaseException()}" });
                }

                return Ok();
            }

            return StatusCode(500, new { Message = $"Os dados do livro não foi cadastrado corretamente." });
        }

        [HttpPut("{id}")]
        //[ValidateAntiForgeryToken]
        public IActionResult Put(string id, [FromBody]Book book)
        {
            Guid bookId = Guid.Parse(id);
            Book bookFound = _bookService.FindByID(bookId);
            if (bookFound == null)
                return StatusCode(204, new { Message = $"Livro não encontrado!" });

            if (ModelState.IsValid)
            {
                try
                {
                    this._bookService.Update(bookId, book);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Message = $"Ocorreu um erro ao tentar atualizar o livro.\n\nErro: {ex.GetBaseException()}" });
                }

                return Ok();
            }

            return StatusCode(500, new { Message = $"Os dados do livro não foi preenchido corretamente." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Guid bookId = Guid.Parse(id);
            if(_bookService.FindByID(bookId) == null)
                return StatusCode(204, new { Message = $"Livro não encontrado!" });

            var removed =_bookService.Remove(bookId);
            if(removed)
                return StatusCode(200, new { Message = $"Livro removido com sucesso!" });
            else
                return StatusCode(500, new { Message = $"Ocorreu um erro ao tentar remover o livro." });
        }
    }
}
