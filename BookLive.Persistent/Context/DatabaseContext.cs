using BookLive.Core;
using Microsoft.EntityFrameworkCore;

namespace BookLive.Persistent.Context;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<ReadBook> ReadBooks { get; set; } = null!;

    public readonly string connectionString;

    public DatabaseContext()
    {
        Database.EnsureCreated();

        #region Legacy...

        // Npgsql 6.0 brings some major breaking changes and is not a simple in-place upgrade.
        // Carefully read the breaking change notes below and upgrade with care.
        // https://www.npgsql.org/efcore/release-notes/6.0.html?tabs=annotations#timestamp-rationalization-and-improvements
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

        #endregion Legacy...

        connectionString = "Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=postgres";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=postgres");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Metadata.SetTableName(nameof(Author));
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name).HasMaxLength(128);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Metadata.SetTableName(nameof(Book));
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name).HasMaxLength(128);
        });

        modelBuilder.Entity<ReadBook>(entity =>
        {
            entity.Metadata.SetTableName(nameof(ReadBook));
            entity.HasKey(x => x.Id);
        });
    }

    public int SaveAllChanges()
    {
        var result = SaveChanges();

        return result;
    }

    public async Task<int> SaveAllChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await SaveChangesAsync(cancellationToken);

        return result;
    }
}