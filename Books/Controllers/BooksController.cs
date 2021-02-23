﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Interfaces;
using Books.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Books.Controllers
{
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooks _book;

        public BooksController( IBooks book)
        {
            _book = book;
        }
        
        
        
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            var books = _book.GetBooks();

            if (books == null )
            {
                return NotFound("No existen libros");
            }

            return Ok(books);
        }

        // GET api/<controller>/5
        [HttpGet("{title}", Name = "GetArticuloByTitle")]
        public ActionResult<List<Book>> GetArticuloByTitle( string title)
        {
            var books = _book.SearchBookByTitle(title);

            if (books.Count<=0)
            {
                return NotFound("No existen ningun libro con ese titulo");
            }

            return Ok(books);
        }

        // POST api/<controller>
        [HttpGet("{precio:int}", Name = "GetArticuloByPrecio")]
        public ActionResult<List<Book>> GetArticuloByPrecio(int precio)
        {
            var books = _book.SearchBookByPrice(precio);

            if (books == null)
            {
                return NotFound("No existen ningun libro con ese precio");
            }

            return Ok(books);
        }

    }
}
