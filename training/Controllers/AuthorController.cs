using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using training.Dto;
using training.Repos;

namespace training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepo _repo;

        public AuthorController(IAuthorRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult AddAuthor(AuthorDto author)
        {
            _repo.AddAuthor(author);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var s = _repo.GetAllAuthors();
            return Ok(s);
        }
        [HttpGet("Get By Id")]
        public IActionResult GetAuthorById(int id)
        {
            var s = _repo.GetAuthorById(id);
            return Ok(s);
        }
        [HttpPut]
        public IActionResult UpdateAuther(int id,AuthorDto authorDto)
        {
            _repo.UpdateAuthor(id, authorDto);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            _repo.DeleteAuthor(id);
            return Ok();
        }
    }
}
