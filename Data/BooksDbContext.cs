using Microsoft.EntityFrameworkCore;
namespace BookApi.Data;
using BookApi.Models;
public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();
}