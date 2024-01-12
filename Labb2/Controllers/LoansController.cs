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
    public class LoansController : ControllerBase
    {
        private readonly LibraryContext _context;

        public LoansController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoan()
        {
            return await _context.Loans.ToListAsync();
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetLoan(int id)
        {
            var loan = await _context.Loans.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            return loan;
        }

        //// PUT: api/Loans/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutLoan(int id, Loan loan)
        //{
        //    if (id != loan.LoanID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(loan).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!LoanExists(id))
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

        // POST: api/Loan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Loan")]
        public async Task<ActionResult<Loan>> PostLoan(CreateLoanDTO createLoanDTO)
        {
            // - Hitta UserID på kontexten
            User user = await _context.Users.FindAsync(createLoanDTO.UserID);

            // - Hitta BookCopyID på kontexten
            BookCopy bookCopy = await _context.BookCopies.FindAsync(createLoanDTO.BookCopyID);


            // - Omvandla LoanDTO till Loan
            Loan loan = new Loan
            {
                User = user, //ÄR DETTA NÖDVÄNDIGT?
                UserID = createLoanDTO.UserID,
                BookCopy = bookCopy, // ÄR DETTA NÖDVÄNDIGT?
                BookCopyID = createLoanDTO.BookCopyID,
                LoanDate = createLoanDTO.LoanDate
            };

            // - Registrera bookCopy som utlånad:
            bookCopy.IsAvailable = false;

            // - Lägga till Loan på kontexten
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoan", new { id = loan.LoanID }, loan);
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Return: {id}")]
        public async Task<IActionResult> PutLoan(int id, Loan loan)
        {
            //binder id:t till den specifika boken som lämnas tillbaka
            loan.BookCopyID = id; 

            //ändra lånet
            _context.Entry(loan).State = EntityState.Modified;

            // - Ändra bookCopy.IsAvailable till true igen
            loan.BookCopy.IsAvailable = true;

            // - Lägg till ett ReturnDate
            loan.ReturnDate = DateOnly.FromDateTime(DateTime.Now);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch 
            {
                throw;
            }
            return NoContent();


        }


        //// POST: api/Return
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("Return")]
        //public async Task<ActionResult<Loan>> PostReturn(ReturnLoanDTO returnLoanDTO)
        //{
        //    // - Hitta Loan på kontexten
        //    Loan loan = await _context.Loans.FindAsync(returnLoanDTO)

        //    // - Hitta BookCopyID på kontexten
        //    BookCopy bookCopy = await _context.BookCopies.FindAsync(returnLoanDTO.BookCopyID);


        //    // - Omvandla LoanDTO till Loan

        //    {
        //        BookCopyID = returnLoanDTO.BookCopyID,
        //        ReturnDate = returnLoanDTO.ReturnDate
        //    };

        //    // - Registrera bookCopy tillgänglig igen:
        //    bookCopy.IsAvailable = true;

        //    // - Lägga till Loan på kontexten
        //    _context.Loans.Add(loan);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetLoan", new { id = loan.LoanID }, loan);
        //}



        //// DELETE: api/Loans/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteLoan(int id)
        //{
        //    var loan = await _context.Loans.FindAsync(id);
        //    if (loan == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Loans.Remove(loan);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool LoanExists(int id)
        //{
        //    return _context.Loans.Any(e => e.LoanID == id);
        //}
    }
}
