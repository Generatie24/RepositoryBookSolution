using RepositoryBookApp.Models.DomeinModels;

namespace RepositoryBookApp.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> Books { get; }
        IRepository<Author> Authors { get; }
        IRepository<Genre> Genres { get; }
        IRepository<BookGenre> BookGenres { get; }
        Task<int> CompleteAsync();

    }
}
