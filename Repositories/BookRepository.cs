using JokesWebApp.Data;
using JokesWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesWebApp.Repositories
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context=context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                // CreatedOn =DateTime.UtcNow  ,
                Description = model.Description,
                Title = model.Title,
                TotalPages=model.TotalPages.HasValue ? model.TotalPages.Value : 0,
               // UpdatedOn=DateTime.UtcNow
            };

            await  _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>>  GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks =await _context.Books.ToListAsync();
            if (allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author=book.Author,
                        Category=book.Category,
                        Title=book.Title,
                        Description=book.Description,
                        Id=book.Id,
                        Language=book.Language,
                        TotalPages=book.TotalPages
                    });
                }
            }

            return books;
        }

        public async Task<BookModel>  GetBookById(int id)
        {
            var book =await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Title = book.Title,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    TotalPages = book.TotalPages
                };

                return bookDetails;
            }

            //return DataSource().Where(x => x.Id == id).FirstOrDefault();
            return null;
        }

        public List<BookModel> SearchBook(string title,string authorName)
        {
            return DataSource().Where(x=>x.Author==authorName && x.Title==title).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() {Id=1 ,Title="MVC",Author="Nitsh", Description="This is MVC book",Category="Programming",Language="English",TotalPages=134},
                new BookModel() {Id=2 ,Title="Dot Net",Author="Nitsh", Description="This is MVC book" ,Category="Framework",Language="French",TotalPages=88},
                new BookModel() {Id=3 ,Title="C#",Author="Monika" , Description="This is C# book",Category="Developer",Language="Spanish",TotalPages=4},
                new BookModel() {Id=4 ,Title="Java",Author="Chaudhry" , Description="This is Java book",Category="Engineer",Language="Kiswahili",TotalPages=7},
                new BookModel() {Id=5 ,Title="Python",Author="Bentah" , Description="This is Python book",Category="Software",Language="English",TotalPages=32},
                new BookModel() {Id=6 ,Title="React",Author="Nitsh" , Description="This is React book",Category="Programming",Language="German",TotalPages=11},
            };
        }
    }
}
