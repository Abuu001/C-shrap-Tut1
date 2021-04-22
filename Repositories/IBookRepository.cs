using JokesWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesWebApp.Repositories
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel model);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<List<BookModel>> GetTopBooksAsync(int count);
        List<BookModel> SearchBook(string title, string authorName);
    }
}