using Microsoft.EntityFrameworkCore;
using RepositoryBookApp.Data;
using RepositoryBookApp.Interfaces;
using RepositoryBookApp.Models.DomeinModels;

namespace RepositoryBookApp.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly RepoContext _context;
        public BookRepository(RepoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Book> Books, int Count)> GetAllBooksWithAuthorsAndGenresAsync(int pageNumber, int pageSize)
        {
            var count = await _context.Books.CountAsync();
            var books = await _context.Books
                .Include(b => b.Author)
                    .Include(b => b.BookGenres)
                        .ThenInclude(bg => bg.Genre)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (books, count);
        }

        public Task<Book> GetBookWithGenresAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}
