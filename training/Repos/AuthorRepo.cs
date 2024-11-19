using training.Dto;
using training.Models;

namespace training.Repos
{
    public class AuthorRepo:IAuthorRepo
    {
        private readonly AppDbContext _context;

        public AuthorRepo(AppDbContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorDto authorDto)
        {
            Author a1 = new Author
            {
                AuthorName = authorDto.AuthorName,
                AuthorEmail = authorDto.AuthorEmail,
                AuthorPhone = authorDto.AuthorPhone
            };
            _context.authors.Add(a1);
            _context.SaveChanges();
        }
        public List<Author> GetAllAuthors()
        {
            var s = _context.authors.ToList();
            return s;
        }
        public Author GetAuthorById(int id)
        {
            var s = _context.authors.FirstOrDefault(i => i.AuthorId == id);
            return s;
        }
        public void UpdateAuthor(int id,AuthorDto authorDto)
        {
            var s = _context.authors.FirstOrDefault(i => i.AuthorId == id);
            s.AuthorName = authorDto.AuthorName;
            s.AuthorPhone = authorDto.AuthorPhone;
            s.AuthorEmail = authorDto.AuthorEmail;
            _context.authors.Update(s);
            _context.SaveChanges();
        }
        public void DeleteAuthor(int id)
        {
            var s = _context.authors.FirstOrDefault(i => i.AuthorId == id);
            _context.authors.Remove(s);
            _context.SaveChanges();
        }

    }
}
