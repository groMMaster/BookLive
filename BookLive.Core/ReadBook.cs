namespace BookLive.Core;

public class ReadBook
{
    public uint Id { get; set; }
    public Book Book { get; set; } = new Book();
    public uint BookId { get; set; }
    public BookTypeEnum BookType { get; set; }
    public DateTime Date { get; set; }
    public decimal Rating { get; set; }

    public void Validate()
    {
        Book.Validate();

        if (Rating is (< 0 or > 10))
        {
            throw new ArgumentException(
                $"Значение рейтинга (свойство {nameof(Rating)}) должно быть в пределах от 0 до 10 включительно. Вы передали значение {Rating}");
        }
    }
}