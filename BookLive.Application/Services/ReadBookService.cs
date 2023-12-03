using BookLive.Application.Services.Interfaces;
using BookLive.Core;
using BookLive.Persistent.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLive.Persistent.Repository.Interfaces;

namespace BookLive.Application.Services;

public class ReadBookService : IReadBookService
{
    private readonly IReadBookRepository _repository;

    public ReadBookService(IReadBookRepository repository)
    {
        this._repository = repository;
    }

    public void AddReadBook(ReadBook readBook)
    {
        _repository.AddReadBook(readBook);
    }
}
