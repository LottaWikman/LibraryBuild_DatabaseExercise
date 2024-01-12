using System.ComponentModel.DataAnnotations;

namespace Labb2.Model;

public class Loan
{
    public int LoanID { get; set; } //PK
    public User User { get; set; } //Navigationsproperty
    public int UserID { get; set; }
    public BookCopy BookCopy {  get; set; } //Navigationsproperty
    public int BookCopyID { get; set; }
    public DateOnly LoanDate { get; set; }
    public DateOnly? ReturnDate { get; set; }


}
