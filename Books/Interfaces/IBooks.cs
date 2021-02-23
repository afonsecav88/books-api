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

      List<Book> GetBooks();

      List<Book> SearchBookByTitle(string title);

     Book SearchBookByPrice(int price);

    }
}
