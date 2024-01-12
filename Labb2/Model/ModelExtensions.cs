using Labb2.DTOs;
using Labb2.Model;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;

namespace Labb2.Model;

public static class ModelExtensions
{

    public static Book ToBook(this BookWithNewAuthorDTO bookWithNewAuthorDTO)
    {
        List<Author> authors = new List<Author>();

        foreach (NewAuthorDTO newAuthorDTO in bookWithNewAuthorDTO.NewAuthorDTOs)
        {
            Author newAuthor = newAuthorDTO.ToAuthor();
            authors.Add(newAuthor);
        }

        return new Book
        {
            ISBN = bookWithNewAuthorDTO.ISBN,
            Authors = authors,
            Title = bookWithNewAuthorDTO.Title,
            PublicationYear = bookWithNewAuthorDTO.PublicationYear,
            Rating = bookWithNewAuthorDTO.Rating,
        };
    }
    
    public static Author ToAuthor(this NewAuthorDTO newAuthorDTO)
    {
        Author newAuthor = new Author
        {
            FirstName = newAuthorDTO.FirstName,
            LastName = newAuthorDTO.LastName
        };

        return newAuthor;
    }

    public static Book ToBook(this BookWithExistingAuthorDTO bookWithExistingAuthorDTO)
{
    return new Book
    {
        ISBN = bookWithExistingAuthorDTO.ISBN,
        Title = bookWithExistingAuthorDTO.Title,
        PublicationYear = bookWithExistingAuthorDTO.PublicationYear,
        Rating = bookWithExistingAuthorDTO.Rating,

    };
}


    public static User ToUser(this UserDTO userDTO)
    {
        return new User
        {
            LibraryCard = userDTO.LibraryCard,
            FirstName = userDTO.FirstName,
            LastName = userDTO.LastName
        };
    }
}
