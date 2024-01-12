namespace Labb2.DTOs;

public class BookWithNewAuthorDTO
{
    public int ISBN { get; set; }
    public List<NewAuthorDTO> NewAuthorDTOs { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int PublicationYear { get; set; }
    public double? Rating { get; set; }
}
