using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using training.Dto;
using training.Repos;

namespace training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepo _repo;

        public GenreController(IGenreRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult AddGenre(GenreDto genre)
        {
            _repo.AddGenre(genre);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetGenres()
        {
            var s = _repo.GetAllGenre();
            return Ok(s);
        }
        [HttpGet("Get By Id")]
        public IActionResult GetGenreById(int id)
        {
            var s = _repo.GetGenreById(id);
            return Ok(s);
        }
        [HttpPut]
        public IActionResult UpdateGenre(int id,GenreDto genre)
        {
            _repo.UpdateGenre(id, genre);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteGenre(int id)
        {
            _repo.DeleteGenre(id);
            return Ok();
        }
    }
}
