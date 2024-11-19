namespace training.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public DateTime PublishedYear { get; set; }
        public List<Author> authors { get; set; }
        public List<Genre> genres { get; set; }
    }
}
