using BookLive.Core;

namespace BookLive.Persistent.Repository.Interfaces;

public interface IReadBookRepository
{
    void AddReadBook(ReadBook readBook, CancellationToken cancellationToken = default);
}
