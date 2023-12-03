using BookLive.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLive.Persistent.Repository.Interfaces;

public interface IAuthorRepository
{
    Task AddAuthor(Author author, CancellationToken cancellationToken = default);
}
