using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labb2.Model;
using Labb2.DTOs;

namespace Labb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCopiesController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BookCopiesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/BookCopies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCopy>>> GetBookCopy()
        {
            return await _context.BookCopies.ToListAsync();
        }

        // GET: api/BookCopies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookCopy>> GetBookCopy(int id)
        {
            var bookCopy = await _context.BookCopies.FindAsync(id);

            if (bookCopy == null)
            {
                return NotFound();
            }

            return bookCopy;
        }

        //// PUT: api/BookCopies/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBookCopy(int id, BookCopy bookCopy)
        //{
        //    if (id != bookCopy.BookCopyID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(bookCopy).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookCopyExists(id))
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

        // POST: api/BookCopies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookCopy>> PostBookCopy(BookCopyDTO bookCopyDTO)
        {
            //1. Jag vill använda bookCopyDTO.BookID för att hitta ett Book.BookID
            Book book = await _context.Books.FindAsync(bookCopyDTO.BookID);

            //2. Omvandla BookCopyDTO till en BookCopy:

            BookCopy bookCopy = new BookCopy
            {
                Book = book, //ÄR DETTA NÖDVÄNDIGT?
                BookID = bookCopyDTO.BookID,
                IsAvailable = true
            };

            //3. Jag vill sedan skapa den nya BookCopy på kontexten:
            _context.BookCopies.Add(bookCopy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookCopy", new { id = bookCopy.BookCopyID }, bookCopy);
        }

        // DELETE: api/BookCopies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookCopy(int id)
        {
            var bookCopy = await _context.BookCopies.FindAsync(id);
            if (bookCopy == null)
            {
                return NotFound();
            }

            _context.BookCopies.Remove(bookCopy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookCopyExists(int id)
        {
            return _context.BookCopies.Any(e => e.BookCopyID == id);
        }
    }
}
