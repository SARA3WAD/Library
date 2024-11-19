using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using training.Dto;
using training.Models;
using training.Repos;

namespace training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _repo;

        public BookController(IBookRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult AddBook(BookDto book, string name)
        {
            _repo.AddBook(book, name);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var s = _repo.GetAllBooks();
            return Ok(s);
        }
        [HttpGet("Get By Id")]
        public IActionResult GetBookById(int id)
        {
            var s = _repo.GetBookById(id);
            return Ok(s);
        }
        [HttpPut]
        public IActionResult UpdateBook(int id,BookDto bookDto)
        {
            _repo.UpdateBook(id, bookDto);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            _repo.DeleteBook(id);
            return Ok();
        }
        [HttpGet("Get Author and Genre")]
        public IActionResult GetBookwithAuthorandGenre()
        {
            var S = _repo.GetBookwithAuthorandGenre();
            return Ok(S);
        }
        [HttpPost("Add Author and Genre")]
        public IActionResult AddBookandAuthorandGenre(BookSecondDto bookSecondDto)
        {
            _repo.AddBookandAuthorandGenre(bookSecondDto);
            return Ok();
        }
        [HttpPut("update AUther with book")]
        public IActionResult UpdateBookAuthor(BookSecondDto book, int bookid)
        {
            _repo.UpdateBookAuthor(book,bookid);
            return Ok();
        }

    }
}
