using Labb2.Model;

namespace Labb2.DTOs;

public class ReturnLoanDTO
{
    public int BookCopyID { get; set; }
    public DateOnly? ReturnDate = DateOnly.FromDateTime(DateTime.Now);

}
