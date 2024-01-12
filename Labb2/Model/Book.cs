using System.ComponentModel.DataAnnotations;

namespace Labb2.Model;

public class Book
{
    public int BookID { get; set; } //PK
    public int ISBN {  get; set; }
    public List<Author> Authors { get; set; } = new();
    public string Title { get; set; } = null!;
    public int PublicationYear { get; set; }
    public double? Rating { get; set; }

}
