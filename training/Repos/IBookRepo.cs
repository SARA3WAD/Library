using training.Dto;
using training.Models;

namespace training.Repos
{
    public interface IBookRepo
    {
        public List<Book> GetAllBooks();
        public Book GetBookById(int id);
        public void UpdateBook(int id, BookDto book);
        public void DeleteBook(int id);
        public List<BookSecondDto> GetBookwithAuthorandGenre();
        public void AddBookandAuthorandGenre(BookSecondDto book);
        public void AddBook(BookDto bookDto, string name);
        public void UpdateBookAuthor(BookSecondDto book, int bookid);

    }
}
