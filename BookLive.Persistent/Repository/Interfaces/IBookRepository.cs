using BookLive.Core;
using BookLive.Persistent.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLive.Persistent.Repository.Interfaces;

public interface IBookRepository
{
    void AddBook(Book book, CancellationToken cancellationToken = default);
}
