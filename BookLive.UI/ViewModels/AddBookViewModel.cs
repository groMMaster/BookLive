using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using BookLive.Application.Services;
using BookLive.Application.Services.Interfaces;
using BookLive.Application.Utils;
using BookLive.Core;
using BookLive.Persistent.Context;
using BookLive.Persistent.Repository;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace BookLive.UI.ViewModels;

public class AddBookViewModel : ViewModelBase
{
    public AddBookViewModel()
    {
        ReadBook = new ReadBook()
        {
            Book = new Book
            {
                Author = new Author()
            },

            Date = DateTime.Now.ToUniversalTime()
        };

        BookSizes = EnumExtensions.GetEnumValues<BookSizeEnum>()
            .Select(x => x.GetDescription()).ToArray();

        BookTypes = EnumExtensions.GetEnumValues<BookTypeEnum>()
            .Select(x => x.GetDescription()).ToArray();

        ImagePath = LoadFromResource(new Uri("avares://BookLive.UI/Assets/add_image.png"));

        var dbContext = new DatabaseContext();
        var repository = new ReadBookRepository(dbContext);
        ReadBookService = new ReadBookService(repository);
    }

    public ReadBook ReadBook { get; }

    public IEnumerable<string> BookSizes { get; }

    public IEnumerable<string> BookTypes { get; }

    public string BookSize
    {
        get => ReadBook.Book.Size.GetDescription();
        set
        {
            if (EnumExtensions.TryParse<BookSizeEnum>(value, out var result))
            {
                ReadBook.Book.Size = result;
            }
        }
    }

    public string BookType
    {
        get => ReadBook.BookType.GetDescription();
        set
        {
            if (EnumExtensions.TryParse<BookTypeEnum>(value, out var result))
            {
                ReadBook.BookType = result;
            }
        }
    }

    public DateOnly Date
    {
        get
        {
            var date = ReadBook.Date;
            return new DateOnly(date.Year, date.Month, date.Day);
        }
        set => ReadBook.Date = new DateTime(value.Year, value.Month, value.Day).ToUniversalTime();
    }

    public Bitmap ImagePath { get; }

    public IReadBookService ReadBookService { get; }

    private static Bitmap LoadFromResource(Uri resourceUri)
    {
        return new Bitmap(AssetLoader.Open(resourceUri));
    }
}