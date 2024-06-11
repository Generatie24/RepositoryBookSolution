﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RepositoryBookApp.Helper;
using RepositoryBookApp.Interfaces;
using RepositoryBookApp.Models.DomeinModels;
using RepositoryBookApp.Models.ViewModels;



namespace RepositoryBookApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BooksController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 2)
        {
            var (books, count) = await _unitOfWork.BooksRelated.GetAllBooksWithAuthorsAndGenresAsync(pageNumber, pageSize);

            var booksViewModels = books.Select(book => new BookIndexViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorName = book.Author.Name,
                GenreNames = book.BookGenres.Select(bg => bg.Genre.Name).ToList(),
                IsAvailable = book.IsAvailable,
                IsNewRelease = book.IsNewRelease,
                IsBestSeller = book.IsBestSeller,
                BindingType = book.BindingType.ToString()
            }).ToList();

            var paginatedBooks = new PaginatedList<BookIndexViewModel>(booksViewModels, count, pageNumber, pageSize);

            var viewModel = new BookListViewModel
            {
                Books = paginatedBooks,
                TotalBooks = count
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateBookViewModel
            {
                Authors = (await _unitOfWork.Authors.GetAllAsync()).ToList(),
                Genres = (await _unitOfWork.Genres.GetAllAsync()).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Authors = (await _unitOfWork.Authors.GetAllAsync()).ToList();
                viewModel.Genres = (await _unitOfWork.Genres.GetAllAsync()).ToList();
            }

            string imagePath = await SaveImageAsync(viewModel.Image);
            if (imagePath == null)
            {
                viewModel.Authors = (await _unitOfWork.Authors.GetAllAsync()).ToList();
                viewModel.Genres = (await _unitOfWork.Genres.GetAllAsync()).ToList();
                return View(viewModel);
            }
            var newBook = new Book
            {
                Title = viewModel.Books.Title,
                AuthorId = viewModel.SelectedAuthorId,
                IsAvailable = viewModel.Books.IsAvailable,
                IsNewRelease = viewModel.Books.IsNewRelease,
                IsBestSeller = viewModel.Books.IsBestSeller,
                BindingType = viewModel.Books.BindingType,
                ImagePath = imagePath
            };
            await _unitOfWork.Books.AddAsync(newBook);
            await _unitOfWork.CompleteAsync();

            if (viewModel.SelectedGenres != null && viewModel.SelectedGenres.Any())
            {
                foreach (var genreId in viewModel.SelectedGenres)
                {
                    var bookGenre = new BookGenre
                    {
                        BookId = newBook.BookId,
                        GenreId = genreId
                    };
                    await _unitOfWork.BookGenres.AddAsync(bookGenre);
                }

                await _unitOfWork.CompleteAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        private async Task<string> SaveImageAsync(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return null;
            }

            string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            string filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return "/images/" + uniqueFileName;
        }


    }
}
