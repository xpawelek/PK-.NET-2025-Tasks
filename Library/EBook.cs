namespace Library;

public class EBook : Book
{
    private EBookFormat FileFormat;
    public EBook(string title, string author, EBookFormat fileFormat) : base(title, author)
    {
        FileFormat = fileFormat;
    }
    
    public void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Format: {FileFormat}");
    }
}