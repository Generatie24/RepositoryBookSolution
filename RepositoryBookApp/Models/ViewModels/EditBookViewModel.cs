using RepositoryBookApp.Enums;
using RepositoryBookApp.Models.DomeinModels;

namespace RepositoryBookApp.Models.ViewModels
{
    public class EditBookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public List<int> SelectedGenres { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsNewRelease { get; set; }
        public bool IsBestSeller { get; set; }
        public BindingType? BindingType { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; } = "/images/default.jpg"; // Standaardafbeel
    }
}
