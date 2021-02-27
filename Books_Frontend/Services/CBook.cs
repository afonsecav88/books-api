using Books_Frontend.Interface;
using Books_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Books_Frontend.Services
{
    public class CBook : IBook
    {
        private readonly IBase _iBase;

        public CBook(IBase IBase)
        {
            _iBase = IBase;
        }
        
        public async Task<IAsyncEnumerable<Book>> GetBooks()
        {           
                HttpClient client = _iBase.Initial();
                HttpResponseMessage res = await client.GetAsync("client");
                if (res.IsSuccessStatusCode)
                {
                    var books = await client.GetStringAsync("client");
                    IAsyncEnumerable<Book> libros = JsonConvert.DeserializeObject<IAsyncEnumerable<Book>>(books);
                    return libros;
                }

            return null;

            }                 
                 

        }
    }


