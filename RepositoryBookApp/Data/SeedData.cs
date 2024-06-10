using Microsoft.EntityFrameworkCore;
using RepositoryBookApp.Enums;
using RepositoryBookApp.Models.DomeinModels;

namespace RepositoryBookApp.Data
{
    public static class SeedData
    {
        public static void AddRecords(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
            new Author { AuthorId = 1, Name = "Author 1" },
            new Author { AuthorId = 2, Name = "Author 2" }
        );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, Name = "Genre 1" },
                new Genre { GenreId = 2, Name = "Genre 2" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Book 1", AuthorId = 1, IsAvailable = true, IsNewRelease = true, IsBestSeller = false, BindingType = BindingType.Hardcover, ImagePath = "" },
                new Book { BookId = 2, Title = "Book 2", AuthorId = 2, IsAvailable = false, IsNewRelease = false, IsBestSeller = true, BindingType = BindingType.Paperback, ImagePath = "" }
            );

            modelBuilder.Entity<BookGenre>().HasData(
                new BookGenre { BookId = 1, GenreId = 1 },
                new BookGenre { BookId = 2, GenreId = 2 }
            );
        }
    }
}
