using Microsoft.EntityFrameworkCore;
using RepositoryBookApp.Enums;

namespace RepositoryBookApp.Models.DomeinModels
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public bool IsAvailable { get; set; }
        public bool IsNewRelease { get; set; }
        public bool IsBestSeller { get; set; }

        public BindingType? BindingType { get; set; }
        public string? ImagePath { get; set; }
    }
}
