using Books.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Interfaces
{
    public interface IBooks
    {

        Task<IEnumerable<Book>> GetBooks();

        Task<IEnumerable<Book>> SearchBookByTitle(string title);

        Task<Book> SearchBookByPrice(int price);

    }
}
