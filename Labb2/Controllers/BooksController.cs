using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labb2.Model;
using Labb2.DTOs;
using System.Diagnostics;

namespace Labb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        //// PUT: api/Books/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBook(int id, Book book)
        //{
        //    if (id != book.ISBN)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(book).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/BooksWithNewAuthor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("BookWithNewAuthor")]
        public async Task<ActionResult<Book>> PostBookWithNewAuthor(BookWithNewAuthorDTO bookWithNewAuthorDTO)
        {
            Book book = bookWithNewAuthorDTO.ToBook();

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new { id = book.BookID }, book);
        }

        // POST: api/BooksWithExistingAuthor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("BookWithExistingAuthor")]
        public async Task<ActionResult<Book>> PostBookWithExistingAuthor(BookWithExistingAuthorDTO bookWithExistingAuthorDTO)
        {
            Debug.WriteLine(bookWithExistingAuthorDTO.ToString());


            List<Author> authors = new();

            foreach(int id in bookWithExistingAuthorDTO.AuthorIDs)
            {
                Author author = await _context.Authors.FindAsync(id);
                authors.Add(author);
            }

            Book book = new Book
            {
                ISBN = bookWithExistingAuthorDTO.ISBN,
                Authors = authors,  
                Title = bookWithExistingAuthorDTO.Title,
                PublicationYear = bookWithExistingAuthorDTO.PublicationYear,
                Rating = bookWithExistingAuthorDTO.Rating,
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.BookID }, book);
        }


        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.ISBN == id);
        }
    }
}
