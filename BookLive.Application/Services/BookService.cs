using BookLive.Application.Services.Interfaces;
using BookLive.Core;
using BookLive.Persistent.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLive.Application.Services;

public class BookService : IBookService
{
    private IBookRepository repository;

    public BookService(IBookRepository repository)
    {
        this.repository = repository;
    }

    public void AddBook(Book book)
    {
        repository.AddBook(book);
    }
}
