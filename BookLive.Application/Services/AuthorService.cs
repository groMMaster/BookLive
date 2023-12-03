using BookLive.Application.Services.Interfaces;
using BookLive.Core;
using BookLive.Persistent.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLive.Application.Services;

public class AuthorService : IAuthorService
{
    private IAuthorRepository repository;

    public AuthorService(IAuthorRepository repository)
    {
        this.repository = repository;
    }

    public async Task AddAuthor(Author author)
    {
        await repository.AddAuthor(author);
    }
}
