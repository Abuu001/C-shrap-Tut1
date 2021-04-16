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
