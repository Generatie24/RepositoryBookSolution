namespace RepositoryBookApp.Models.ViewModels
{
    public class BookIndexViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public IEnumerable<string> GenreNames { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsNewRelease { get; set; }
        public bool IsBestSeller { get; set; }
        public string BindingType { get; set; }
    }
}
