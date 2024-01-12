using Labb2.Model;

namespace Labb2.DTOs;

public class CreateLoanDTO
{
    public int UserID { get; set; }
    public int BookCopyID { get; set; }

    public DateOnly LoanDate = DateOnly.FromDateTime(DateTime.Now);

}
