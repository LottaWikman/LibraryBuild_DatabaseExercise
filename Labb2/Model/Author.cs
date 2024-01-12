using System.ComponentModel.DataAnnotations;

namespace Labb2.Model;

public class Author
{
    public int AuthorID { get; set; } //PK
    public string FirstName { get; set; } = null!; //jag lovar att den här propertyn aldrig kommer vara null
    public string LastName { get; set; } = null!;
    public List<Book> Books { get; } = new();
}
