using System.ComponentModel.DataAnnotations;

namespace Labb2.Model;

public class BookCopy
{
    public int BookCopyID { get; set; } //PK
    public Book? Book { get; set; } // GÅR inte att länka i controllern eftersom den är av typen Book
    public int BookID { get; set; } //testar att skapa en ny property för att controllern ska fungera
    public bool IsAvailable { get; set; } = true;
}
