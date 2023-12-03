using System.ComponentModel;

namespace BookLive.Core;

public enum BookSizeEnum
{
    [Description("Рассказ")]
    Small,

    [Description("Повесть")]
    Middle,

    [Description("Роман")]
    Large
}