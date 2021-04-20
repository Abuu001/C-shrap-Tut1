using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JokesWebApp.Models;
using JokesWebApp.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace JokesWebApp.Controllers
{
    public class BookController : Controller
    {

        public readonly BookRepository _bookRepository =null;
        private readonly IWebHostEnvironment _webHostEnvironment ;
        public BookController(BookRepository context, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = context;
            _webHostEnvironment = webHostEnvironment;
           // _bookRepository = new BookRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult>  GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        public async Task<ViewResult> GetBook(int id )
        {
            //var data= _bookRepository.GetBookById(id);
            //return View(data);
            // we can use this method to pass different data from different sources
            dynamic data =  new System.Dynamic.ExpandoObject();
            data.book = _bookRepository.GetBookById(id);
            data.Name = "Abluu";
            return View(data);
        }

        public ViewResult AddNewBook(bool isSuccess=false,int bookId =0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
              var id =await  _bookRepository.AddNewBook(bookModel);

                //if there is a selected photo do this
                if(bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                    folder += Guid.NewGuid().ToString() + bookModel.CoverPhoto.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                  await  bookModel.CoverPhoto.CopyToAsync(new FileStream(serverFolder,FileMode.Create));

                }

                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.IsSuccess = false;
            ViewBag.BookId = 0;

            return View();
        }

        public List<BookModel> SearchBook(string bookName ,string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }
    }
}
