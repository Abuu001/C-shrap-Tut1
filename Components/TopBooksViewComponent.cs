using JokesWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesWebApp.Components
{
    public class TopBooksViewComponent :ViewComponent
    {
        public readonly BookRepository _bookRepository;
        public TopBooksViewComponent(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books = await _bookRepository.GetTopBooksAsync();
            return View(books);
        }
    }
}
