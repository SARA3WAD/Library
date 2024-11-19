using Microsoft.EntityFrameworkCore;
using training.Dto;
using training.Models;

namespace training.Repos
{
    public class BookRepo:IBookRepo
    {
        private readonly AppDbContext _context;

        public BookRepo(AppDbContext context)
        {
            _context = context;
        }
        public void AddBook(BookDto bookDto,string name)
        {
            var s = _context.books.FirstOrDefault(i => i.BookTitle == name);
            if (s != null)
            {
                throw new Exception("this title already exist");
            }
            Book b1 = new Book
            {
                BookTitle = bookDto.BookTitle,
                PublishedYear = bookDto.PublishedYear
            };
            _context.books.Add(b1);
            _context.SaveChanges();
        }
        public List<Book> GetAllBooks()
        {
            var s = _context.books.ToList();
            return s;
        }
        public Book GetBookById(int id)
        {
            var s = _context.books.FirstOrDefault(i => i.BookId == id);
            return s;
        }
        public void UpdateBook(int id,BookDto book)
        {
            var s = _context.books.FirstOrDefault(i => i.BookId == id);
            s.BookTitle = book.BookTitle;
            s.PublishedYear = book.PublishedYear;
            _context.books.Update(s);
            _context.SaveChanges();
        }
        public void DeleteBook(int id)
        {
            var s = _context.books.FirstOrDefault(i => i.BookId == id);
            _context.books.Remove(s);
            _context.SaveChanges();
        }
        public List<BookSecondDto> GetBookwithAuthorandGenre()
        {
            var s = _context.books.Include(i => i.authors)
                .Include(i => i.genres)
                .Select(i => new BookSecondDto
                {
                    BookTitle = i.BookTitle,
                    PublishedYear = i.PublishedYear,
                    authorDtos = i.authors.Select(i => new AuthorDto
                    {
                        AuthorName = i.AuthorName,
                        AuthorEmail = i.AuthorEmail,
                        AuthorPhone = i.AuthorPhone
                    }).ToList(),
                    genreDtos = i.genres.Select(i => new GenreDto
                    {
                        GenreName = i.GenreName
                    }).ToList()
                }).ToList();
            return s;
        }
        public void AddBookandAuthorandGenre(BookSecondDto book)
        {
            Book b1 = new Book
            {
                BookTitle = book.BookTitle,
                PublishedYear = book.PublishedYear,
                authors = book.authorDtos.Select(i => new Author
                {
                    AuthorName = i.AuthorName,
                    AuthorEmail = i.AuthorEmail,
                    AuthorPhone = i.AuthorPhone,
                }).ToList(),
                genres = book.genreDtos.Select(i => new Genre
                {
                    GenreName = i.GenreName
                }).ToList()
            };
            _context.books.Add(b1);
            _context.SaveChanges();
        }
        public void UpdateBookAuthor(BookSecondDto book,int bookid)
        {
            var s = _context.books.Include(i => i.authors).FirstOrDefault(i => i.BookId == bookid);
            s.BookTitle = book.BookTitle;
            s.authors = book.authorDtos.Select(i => new Author
            {
                AuthorName = i.AuthorName,
                AuthorEmail = i.AuthorEmail,
                AuthorPhone = i.AuthorPhone
            }).ToList();
            _context.books.Update(s);
            _context.SaveChanges();
        }
       public void DeleteBookandauthor(int bookid)
        {
            var s = _context.books.Include(i => i.authors)
                .Where(i => i.BookId == bookid).Select(i => new Book
                {
                    BookTitle = i.BookTitle,
                    authors = i.authors.Select(i => new Author
                    {
                        AuthorName = i.AuthorName,
                        AuthorEmail = i.AuthorEmail,
                        AuthorPhone = i.AuthorPhone
                    }).ToList()
                }).ToList();
            var y = _context.books.FirstOrDefault(i => i.BookId == bookid);
            _context.books.RemoveRange(s);
            _context.SaveChanges();
        }
    }
}
