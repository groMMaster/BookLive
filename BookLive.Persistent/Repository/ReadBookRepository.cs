using BookLive.Core;
using BookLive.Persistent.Context;
using BookLive.Persistent.Repository.Interfaces;

namespace BookLive.Persistent.Repository;

public class ReadBookRepository : IReadBookRepository
{
    private readonly IDatabaseContext context;

    public ReadBookRepository(IDatabaseContext context)
    {
        this.context = context;
    }

    public void AddReadBook(ReadBook readBook, CancellationToken cancellationToken = default)
    {
        context.ReadBooks.Add(readBook);

        context.SaveAllChanges();
    }
}
