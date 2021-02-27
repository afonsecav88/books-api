using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Books_Frontend.Models;
using Books_Frontend.Services;
using Books_Frontend.Interface;
using System.Net.Http;

namespace Books_Frontend.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBook _iBook;
                      

        public BookController(ILogger<BookController> logger , IBook IBook )
        {
            _logger = logger;            
            _iBook = IBook;
        }

        public async Task<ActionResult<IAsyncEnumerable<Book>>> Index()
        {
            try
            {
               var books= await _iBook.GetBooks();
                return View(books);
            }
            catch (HttpRequestException)
            {
              throw;
            }           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
