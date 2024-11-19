using training.Dto;
using training.Models;

namespace training.Repos
{
    public class GenreRepo:IGenreRepo
    {
        private readonly AppDbContext _context;

        public GenreRepo(AppDbContext context)
        {
            _context = context;
        }
        public void AddGenre(GenreDto genreDto)
        {
            Genre g1 = new Genre
            {
                GenreName = genreDto.GenreName
            };
            _context.genres.Add(g1);
            _context.SaveChanges();
        }
        public List<Genre> GetAllGenre()
        {
            var s = _context.genres.ToList();
            return s;
        }
        public Genre GetGenreById(int id)
        {
            var s = _context.genres.FirstOrDefault(i => i.GenreId == id);
            return s;
        }
        public void UpdateGenre(int id,GenreDto genre)
        {
            var s = _context.genres.FirstOrDefault(i => i.GenreId == id);
            s.GenreName = genre.GenreName;
            _context.genres.Update(s);
            _context.SaveChanges();
        }
        public void DeleteGenre(int id)
        {
            var s = _context.genres.FirstOrDefault(i => i.GenreId == id);
            _context.genres.Remove(s);
            _context.SaveChanges();
        }
    }
}
