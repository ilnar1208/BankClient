using Microsoft.EntityFrameworkCore;

namespace BankClient.Dal.Ef;

/// <summary>Контекст данных.</summary>
public class BankClientDataContext : DbContext
{
    public DbSet<User> User { get; set; } = null!;
    public DbSet<UserAccount> UserAccount { get; set; } = null!;

    public BankClientDataContext(DbContextOptions<BankClientDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("bank_client");
    }
}
