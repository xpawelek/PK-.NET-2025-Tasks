using Microsoft.EntityFrameworkCore;
using BookApi.Models;
using BookApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BooksDbContext>(options =>
    options.UseSqlite("Data Source=books.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BooksDbContext>();
    db.Database.EnsureCreated();
}

app.MapGet("/api/books", async (BooksDbContext db) => (
    await db.Books.ToListAsync()
    ));

app.MapGet("/api/books/{id}", async (int id, BooksDbContext db) => (
    await db.Books.FirstOrDefaultAsync(b => b.Id == id)
    ));

app.MapPost("/api/books", async (Book book, BooksDbContext db) =>
{
    db.Books.Add(book);
    await db.SaveChangesAsync();
    return Results.Created($"/books/{book.Id}", book);
});

app.MapPut("/api/books/{id}", async (int id, Book input, BooksDbContext db) =>
{
   var book = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
   if(book is null)
       return Results.NotFound();
   
   book.Title = input.Title;
   book.Author = input.Author;
   book.IsRead = input.IsRead;
   book.PublishedYear = input.PublishedYear;
   
   await db.SaveChangesAsync();
   return Results.Ok(book);
   
});

app.MapDelete("/api/books/{id}", async (int id, BooksDbContext db) =>
{
    var book = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
    
    if(book is null)
        return Results.NotFound();
    
    db.Books.Remove(book);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();