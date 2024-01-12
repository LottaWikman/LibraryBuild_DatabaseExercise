using System.ComponentModel.DataAnnotations;

namespace Labb2.Model;

public class User
{
    public int UserID { get; set; } //PK
    public int LibraryCard {  get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public List<Loan>? Loans { get; set; }

}
