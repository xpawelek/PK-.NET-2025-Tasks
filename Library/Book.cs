namespace Library;

public class Book
{
    public static int nextId = 0;
    private int Id;
    private string Title;
    private string Author;
    private bool IsAvailable;
    public int _Id
    {
        get { return Id; }  // Getter
    }

    public string _Title
    {
        get { return Title; }
    }

    public bool _IsAvailable
    {
        get {return IsAvailable;}
        set {IsAvailable = value;}
    }


public Book(string title, string author)
{
        Id = ++nextId;
        Title = title;
        Author = author;
        IsAvailable = true;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Id: {Id}, Title: {Title}, Author: {Author}, Book is available: {IsAvailable}");
    }
}