using Microsoft.EntityFrameworkCore;
using MySQL.EntityFrameworkCore.Extensions;

namespace mysqlefcore
{
  public class BankContext : DbContext
  {
    public DbSet<Account> Account { get; set; }
    public DbSet<BillPay> BillPay { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Login> Login { get; set; }
    public DbSet<Payee> Payee { get; set; }
    public DbSet<Transaction> Transaction { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Publisher>(entity =>
      {
        entity.HasKey(e => e.ID);
        entity.Property(e => e.Name).IsRequired();
      });

      modelBuilder.Entity<Book>(entity =>
      {
        entity.HasKey(e => e.ISBN);
        entity.Property(e => e.Title).IsRequired();
        entity.HasOne(d => d.Publisher)
          .WithMany(p => p.Books);
      });
    }
  }
}       