using Labb2.Model;

namespace Labb2.DTOs;

public class UserDTO
{
    public int LibraryCard { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
