namespace LibraryTests;
using Library;

public class Tests
{
    private Library library;
    private Book book1;
    private Reader reader1, reader2;
    
    [SetUp]
    public void Setup()
    {
        library = new Library();
        book1 = new Book("C# Programming", "John Doe");
        reader1 = new Reader("Jan", "Nowak", "jan.nowak@gmail.com");
        reader2 = new Reader("Wojiech", "Nowak", "wojciech.nowak@gmail.com");
    }
    
    [Test]
    public void TryBorrowTheSameBook_ShouldReturnFalse()
    {
        bool borrow1 = library.BorrowBook(book1._Id, reader1);
        bool borrow2 = library.BorrowBook(book1._Id, reader1);
        Assert.That(borrow1, Is.False);
        Assert.That(borrow2, Is.False);
    }
    
    [Test]
    public void TryToReturnBookYouDontHave_ShouldReturnFalse()
    {
        bool first_return = library.ReturnBook(book1._Id, reader1);
        Assert.That(first_return, Is.False);
    }

    [Test]
    public void AddAndBorrowBook_ShouldReturnTrue()
    {
        library.AddBook(book1);
        bool first_borrow = library.BorrowBook(book1._Id, reader1);
        Assert.That(first_borrow, Is.True);
    }

    [Test]
    public void BorrowAndReturnBook_ShouldReturnTrue()
    {
        library.AddBook(book1);
        library.BorrowBook(book1._Id, reader1);
        bool first_return = library.ReturnBook(book1._Id, reader1);
        Assert.That(first_return, Is.True);
    }

    [Test]
    public void TwoDifferentReadersBorrowSameBook_ShouldReturnFalse()
    {
        library.AddBook(book1);
        bool first_borrow = library.BorrowBook(book1._Id, reader1);
        bool second_borrow = library.BorrowBook(book1._Id, reader2);
        Assert.Multiple(() =>
            {
                Assert.That(first_borrow, Is.True);
                Assert.That(second_borrow, Is.False);
            });
    }

    [Test]
    public void Borrow_NotInLibrary_ShouldReturnFalse()
    {
        bool first_borrow = library.BorrowBook(book1._Id, reader1);
        Assert.That(first_borrow, Is.False);
    }

    [Test]
    public void BookCanBeBorrowedAfterReturn_ShouldReturnTrue()
    {
        library.AddBook(book1);
        library.BorrowBook(book1._Id, reader1);
        library.ReturnBook(book1._Id, reader1);
        bool borrow = library.BorrowBook(book1._Id, reader2);
        Assert.That(borrow, Is.True);
    }
}