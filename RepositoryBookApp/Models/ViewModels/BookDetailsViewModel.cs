namespace RepositoryBookApp.Models.ViewModels
{
    public class BookDetailsViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsNewRelease { get; set; }
        public bool IsBestSeller { get; set; }
        public string BindingType { get; set; }
        public List<string> GenreNames { get; set; } = new List<string>();
        public string ImagePath { get; set; }
    }
}
