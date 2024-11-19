namespace training.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorPhone { get; set; }
        public string AuthorEmail { get; set; }
        public List<Book> books { get; set; }
    }
}
