using BookWebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Repository;

public class BaseDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; Database=tc_book_db; Trusted_Connection=true");
    }

    public DbSet<Book> Books { get; set; }


}
