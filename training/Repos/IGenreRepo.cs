using training.Dto;
using training.Models;

namespace training.Repos
{
    public interface IGenreRepo
    {
        public void AddGenre(GenreDto genreDto);
        public List<Genre> GetAllGenre();
        public Genre GetGenreById(int id);
        public void UpdateGenre(int id, GenreDto genre);
        public void DeleteGenre(int id);
    }
}
