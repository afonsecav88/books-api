using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books_Frontend.Models;
namespace Books_Frontend.Models


{
    public interface IBook
    {
        Task<IAsyncEnumerable<Book>> GetBooks();
    }
}
