using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokesWebApp.Models;
using JokesWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JokesWebApp.Controllers
{
    public class BookController : Controller
    {

        public readonly BookRepository _bookRepository =null;

        public BookController(BookRepository context)
        {
            _bookRepository = context;
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
                int id =await  _bookRepository.AddNewBook(bookModel);

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
