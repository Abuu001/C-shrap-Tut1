using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JokesWebApp.Models;
using JokesWebApp.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        public async Task<ViewResult> GetBook(int id)
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
                    bookModel.CoverImageUrl= await UploadImage(folder,bookModel.CoverPhoto);

                }

                //for multtiple files
                if (bookModel.GalleryFiles != null)
                {
                    string folder = "books/gallery/";

                    bookModel.Gallery = new List<GalleryModel>();

                    foreach (var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name =file.FileName,
                            URL = await UploadImage(folder, file)
                    };

                        bookModel.Gallery.Add(gallery);
                    }

                }

                if (bookModel.BookPdf != null)
                {
                    string folder = "books/pdf/";
                    bookModel.BookPdfUrl = await UploadImage(folder, bookModel.BookPdf);

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

        private async Task<string> UploadImage(string folderPath,IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
  
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        public List<BookModel> SearchBook(string bookName ,string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }
    }
}
