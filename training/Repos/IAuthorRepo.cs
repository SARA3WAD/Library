using training.Dto;
using training.Models;

namespace training.Repos
{
    public interface IAuthorRepo
    {
        public void AddAuthor(AuthorDto authorDto);
        public List<Author> GetAllAuthors();
        public Author GetAuthorById(int id);
        public void UpdateAuthor(int id, AuthorDto authorDto);
        public void DeleteAuthor(int id);
    }
}
