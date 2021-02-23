using Books.Interfaces;
using Books.Models;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Services
{
    public class CBooks : IBooks
    {
        private readonly IMongoCollection<Book> _book;


        //Definiendo los parametros de conexion a la Base de datos
        public CBooks(IDatabaseStrings databaseStrings )        {
          
            var client = new MongoClient(databaseStrings.ConnectionStrings);

            var database = client.GetDatabase(databaseStrings.DatabaseName);

            _book = database.GetCollection<Book>(databaseStrings.CollectionName);            
            
        }


        public List<Book> GetBooks()
        {
            return _book.Find<Book>(x => true).ToList();
        }


        public  List<Book> SearchBookByTitle(string title)
        {
            List<Book> libros = _book.Find<Book>(x => x.title.Contains(title.ToLower().Trim())).ToList();
            return libros;

        }

        public Book SearchBookByPrice(int price)
        {
            return _book.Find<Book>(x => x.price == price).FirstOrDefault();
        }

        
    }
}
