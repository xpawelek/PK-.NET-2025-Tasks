namespace Library;

public enum EBookFormat
{
    PDF,
    EPUB
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        Book book1 = new Book("C# Programming", "John Doe");
        Book book2 = new Book("Design Patterns", "Gamma et al.");
        EBook ebook1 = new EBook("EBook Top!", "Crazy Man", EBookFormat.PDF);

        Reader reader1 = new Reader("Jan", "Nowak", "jan.nowak@gmail.com");
        Reader reader2 = new Reader("Piotr", "Nowak", "jan.nowak@gmail.com");
        Reader reader3 = new Reader("Wojciech", "Nowak", "jan.nowak@gmail.com");

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(ebook1);

       // book1.DisplayInfo();
        if (library.BorrowBook(book1._Id, reader1))
        {
            Console.WriteLine("Book has been borrowed successfully!");
            book1.DisplayInfo();
            reader1.readerInfo();
        }
        else
        {
            Console.WriteLine("Book is not available!");
        }

        Console.WriteLine();
        
        if (library.ReturnBook(book1._Id, reader2))
        {
            Console.WriteLine("Book has been returned successfully!");
        }
        else
        {
            Console.WriteLine("Book was not borrowed by this reader!");
        }
        
        Console.WriteLine();
        
        if (library.BorrowBook(book1._Id, reader2))
        {
            Console.WriteLine("Book has been borrowed successfully!");
            book2.DisplayInfo();
            reader2.readerInfo();
        }
        else
        {
            Console.WriteLine("Book is not available!");
        }
        
        Console.WriteLine();
        
        if (library.ReturnBook(book1._Id, reader1))
        {
            Console.WriteLine("Book has been returned successfully!");
        }
        
        Console.WriteLine();
        
        if (library.BorrowBook(book1._Id, reader2))
        {
            Console.WriteLine("Book has been borrowed successfully!");
            reader2.readerInfo();
        }
        
}
}