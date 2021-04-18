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

        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }

        public ViewResult GetBook(int id )
        {
            //var data= _bookRepository.GetBookById(id);
            //return View(data);
            // we can use this method to pass different data from different sources
            dynamic data = new System.Dynamic.ExpandoObject();
            data.book = _bookRepository.GetBookById(id);
            data.Name = "Abluu";
            return View(data);
        }

        public ViewResult AddNewBook()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddNewBook(BookModel bookModel)
        {
            return View();
        }
        public List<BookModel> SearchBook(string bookName ,string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }
    }
}
