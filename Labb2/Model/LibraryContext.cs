using Microsoft.EntityFrameworkCore;

namespace Labb2.Model;

public class LibraryContext : DbContext
{
    //Konfigurering:
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {

    }


    //Tables I want to have:
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookCopy> BookCopies { get; set; }
}
