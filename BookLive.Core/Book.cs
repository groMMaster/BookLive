namespace BookLive.Core;

public class Book
{
    public uint Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Author Author { get; set; } = new Author();
    public uint AuthorId { get; set; }
    public BookSizeEnum Size { get; set; }

    public string Year { get; set; } = string.Empty;
    // public byte[] Cover { get; set; }

    public void Validate()
    {
        Author.Validate();

        if (Name == string.Empty)
        {
            throw new ArgumentException($"Название книги свойство {nameof(Name)} не может быть пустой строкой.");
        }

        if (Year == string.Empty)
        {
            throw new ArgumentException(
                $"Год выхода книги (свойство {Year}) не может быть пустой строкой. (Если год выхода неизвестен, то нужно написать это, например, так: неизвестно).");
        }
    }
}