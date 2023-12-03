using BookLive.Core;
using BookLive.Persistent.Context;
using BookLive.Persistent.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLive.Persistent.Repository;

public class AuthorRepository : IAuthorRepository
{
    private readonly IDatabaseContext context;

    public AuthorRepository(IDatabaseContext context)
    {
        this.context = context;
    }

    public async Task AddAuthor(Author author, CancellationToken cancellationToken = default)
    {
        await context.Authors.AddAsync(author);

        await context.SaveAllChangesAsync();
    }
}
