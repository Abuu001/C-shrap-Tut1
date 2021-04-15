using JokesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesWebApp.Repositories
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title,string authorName)
        {
            return DataSource().Where(x=>x.Author==authorName && x.Title==title).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() {Id=1 ,Title="MVC",Author="Nitsh"},
                new BookModel() {Id=2 ,Title="Dot Net",Author="Nitsh"},
                new BookModel() {Id=3 ,Title="C#",Author="Monika"},
                new BookModel() {Id=4 ,Title="Java",Author="Chaudhry"},
                new BookModel() {Id=5 ,Title="Python",Author="Bentah"},
                new BookModel() {Id=6 ,Title="React",Author="Nitsh"},
            };
        }
    }
}
