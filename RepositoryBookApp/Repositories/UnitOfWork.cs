using RepositoryBookApp.Data;
using RepositoryBookApp.Interfaces;
using RepositoryBookApp.Models.DomeinModels;

namespace RepositoryBookApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepoContext _context;
        public UnitOfWork(RepoContext context)
        {
            _context = context;

            Books = new Repository<Book>(_context);
            Authors = new Repository<Author>(_context);
            Genres = new Repository<Genre>(_context);
            BookGenres = new Repository<BookGenre>(_context);
            BooksRelated = new BookRepository(_context);
        }

        public IRepository<Book> Books { get; }
        public IRepository<Author> Authors { get; }
        public IRepository<Genre> Genres { get; }
        public IRepository<BookGenre> BookGenres { get; }
        public IBookRepository BooksRelated { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
