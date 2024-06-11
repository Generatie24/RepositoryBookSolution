using RepositoryBookApp.Helper;

namespace RepositoryBookApp.Models.ViewModels
{
    public class BookListViewModel
    {
        public PaginatedList<BookIndexViewModel> Books { get; set; }
        public int TotalBooks { get; set; }

    }
}
