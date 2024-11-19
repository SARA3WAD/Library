namespace training.Dto
{
    public class BookSecondDto
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public DateTime PublishedYear { get; set; }
        public List<AuthorDto> authorDtos { get; set; }
        public List<GenreDto> genreDtos { get; set; }
    }
}
