using BookLive.Core;
using Microsoft.EntityFrameworkCore;

namespace BookLive.Persistent.Context;

public interface IDatabaseContext : IDisposable
{
    DbSet<Author> Authors { get; }
    DbSet<Book> Books { get; }
    DbSet<ReadBook> ReadBooks { get; }

    int SaveAllChanges();
    Task<int> SaveAllChangesAsync(CancellationToken cancellationToken = default);
}