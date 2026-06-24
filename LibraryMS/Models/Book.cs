namespace LibraryMS.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string? ISBN { get; set; }
        public int? CategoryID { get; set; }
        public int? PublisherID { get; set; }
        public int? PublishYear { get; set; }

        public Category? Category { get; set; }
        public Publisher? Publisher { get; set; }
    }
}