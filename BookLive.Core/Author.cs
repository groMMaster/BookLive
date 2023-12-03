namespace BookLive.Core;

public class Author
{
    public uint Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public void Validate()
    {
        if (Name == string.Empty)
        {
            throw new ArgumentException(
                $"Имя автора (свойство {Name}) не может быть пустой строкой. (Если имя автора неизвестно, то нужно написать это, например, так: автор неизвестен).");
        }
    }
}