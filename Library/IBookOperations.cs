namespace Library;

public interface IBookOperations
{
    bool BorrowBook(int bookId, Reader reader);
    bool ReturnBook(int bookId, Reader reader);
}