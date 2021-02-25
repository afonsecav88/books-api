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
        public CBooks(IDatabaseStrings databaseStrings)
        {

            var client = new MongoClient(databaseStrings.ConnectionStrings);

            var database = client.GetDatabase(databaseStrings.DatabaseName);

            _book = database.GetCollection<Book>(databaseStrings.CollectionName);

        }
        

        public async Task<IEnumerable<Book>> GetBooks() => await _book.Find<Book>(x => true).ToListAsync();        


        public async Task<IEnumerable<Book>> SearchBookByTitle(string title) => await _book.Find<Book>(x => x.title.Contains(title.ToLower().Trim())).ToListAsync();
       

        public async Task<Book> SearchBookByPrice(int price) => await _book.Find<Book>(x => x.price == price).FirstOrDefaultAsync();
        


    }
}
