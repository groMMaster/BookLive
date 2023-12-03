using BookLive.Application.Services;
using BookLive.Core;
using BookLive.Persistent.Context;
using BookLive.Persistent.Repository;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var author = new Author
            {
                Id = 1,
                Name= "Вася",
                Surmane = "Косточкин",
            };

            var book = new Book
            {
                Id = 2,
                Name = "Приключения Черешенки",
                Author = author,
                AuthorId = author.Id,
                Size = BookSizeEnum.Large,
                Year = 2009,
            };

            var readBook = new ReadBook
            {
                Id = 3,
                Book = book,
                BookId = book.Id,
                BookType = BookTypeEnum.Audiobook,
                Date = new DateOnly(2023, 11, 13),
                Rating = 4.32m
            };

            var context = new DatabaseContext();

            var readRepository = new ReadBookRepository(context);
            var readService = new ReadBookService(readRepository);

            var bookRepository = new BookRepository(context);
            var bookService = new BookService(bookRepository);

            var authorRepository = new AuthorRepository(context);
            var authorService = new AuthorService(authorRepository);

            //authorService.AddAuthor(author);
            //bookService.AddBook(book);
            readService.AddReadBook(readBook);

            //Console.WriteLine(123);
        }
    }
}