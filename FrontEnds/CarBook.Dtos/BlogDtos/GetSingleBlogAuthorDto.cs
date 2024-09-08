namespace CarBook.Dtos.BlogDtos
{
    public class GetSingleBlogAuthorDto
    {
        public int BlogId { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
