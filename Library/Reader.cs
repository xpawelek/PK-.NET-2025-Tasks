namespace Library;

public class Reader
{
    private static int readerId_stat = 0;
    private int readerId;
    private string firstname;
    private string lastname;
    private string email;
    private List<Book> borrowedBooks = new List<Book>();

    public Reader(string firstname, string lastname, string email)
    {
        readerId = ++readerId_stat;
        this.firstname = firstname;
        this.lastname = lastname;
        this.email = email;
    }

    public void borrowBook(Book book)
    {
        borrowedBooks.Add(book);
    }

    public void returnBook(Book book)
    {
        borrowedBooks.Remove(book);
    }

    public void readerInfo()
    {
        Console.WriteLine($"Id: {readerId}, First Name: {firstname}, Last Name: {lastname}, Email: {email}");
        Console.WriteLine("Borrowed Books: ");
        foreach (var book in borrowedBooks)
        {
            Console.WriteLine($"Id : {book._Id}, Title: {book._Title}");
        }
    }

    public bool readerHasBook(Book book)
    {
        if (borrowedBooks.Contains(book))
            return true;
        return false;
            
    }
}