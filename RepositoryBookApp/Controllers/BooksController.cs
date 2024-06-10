using Microsoft.AspNetCore.Mvc;
using RepositoryBookApp.Interfaces;

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


    }
}
