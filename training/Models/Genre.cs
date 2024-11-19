namespace training.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public List<Book> books { get; set; }
    }
}
