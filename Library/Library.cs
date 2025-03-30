namespace Library;

public class Library : IBookOperations
{
    private List<Book> books;
    private List<Reader> readers;

    public Library()
    {
        books = new List<Book>();
        readers = new List<Reader>();
    }
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RegisterReader(Reader reader)
    {
        readers.Add(reader);
    }

    public void ListAvailableBooks()
    {
        foreach (Book book in books)
        {
            if (book._IsAvailable)
            {
                Console.WriteLine(book);
            }
        }
    }

    public bool BorrowBook(int bookId, Reader reader)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Library is empty.");
            return false;
        }
        var book = books.FirstOrDefault(b => b._Id == bookId);

        if (book == null || !book._IsAvailable)
        {
            return false;
        }

        if (!readers.Contains(reader))
        {
            RegisterReader(reader);
        }
        reader.borrowBook(book);
        book._IsAvailable = false;

        return true;
    }

    public bool ReturnBook(int bookId, Reader reader)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Library is empty.");
            return false;
        }
        
        var book = books.FirstOrDefault(b => b._Id == bookId);

        if (book._IsAvailable == true || !reader.readerHasBook(book))
        {
            //ksiazka nie byla pozyczona
            return false;
        }
        
        reader.returnBook(book);
        book._IsAvailable = true;

        return true;
    }
}