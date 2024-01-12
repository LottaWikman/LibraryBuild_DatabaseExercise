namespace Labb2.DTOs;

public class BookWithExistingAuthorDTO
{
    public int ISBN { get; set; }
    public int[]? AuthorIDs { get; set; }
    public string Title { get; set; } = null!;
    public int PublicationYear { get; set; }
    public double? Rating { get; set; }
}