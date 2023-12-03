using BookLive.Core;
using BookLive.Persistent.Context;
using BookLive.Persistent.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLive.Persistent.Repository;

public class BookRepository : IBookRepository
{
    private readonly IDatabaseContext context;

    public BookRepository(IDatabaseContext context)
    {
        this.context = context;
    }

    public void AddBook(Book book, CancellationToken cancellationToken = default)
    {
        context.Books.Add(book);

        context.SaveAllChanges();
    }
}