using System.ComponentModel;

namespace BookLive.Application.Utils;

/// <summary>
/// Утилитарный класс для Enum-ов.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Попробовать преобразовать строку в Enum-параметр. 
    /// </summary>
    /// <typeparam name="T">Тип Enum-а в параметр которого преобразуем строку.</typeparam>
    /// <param name="s">Строка которую пробуем преобразовать.</param>
    /// <param name="result">В этой переменной будет храниться результат преобразования или default-значение, если преобразование не удастся.</param>
    /// <returns>true в случае успеха, false - неудачи.</returns>
    public static bool TryParse<T>(string? s, out T? result) where T: Enum
    {
        try
        {
            if (s == null)
            {
                throw new ArgumentException();
            }

            result = (T)Enum.Parse(typeof(T), s);
            return true;
        }
        catch
        {
            result = default;
            return false;
        }
        
    }

    /// <summary>
    /// Получить коллекцию параметров переданного типа Enum-а
    /// </summary>
    /// <typeparam name="T">Тип Enum-а</typeparam>
    public static IEnumerable<T> GetEnumValues<T>()
        where T : Enum
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }

    /// <summary>
    /// Получить значение атрибута "Description".
    /// Если указанный атрибут отсутствует, будет возвращено строковое значение перечисления.
    /// </summary>
    /// <param name="value">Значение перечисления.</param>
    /// <returns>Значение атрибута.</returns>
    public static string GetDescription(this Enum value)
    {
        return value.GetAttribute<DescriptionAttribute>()?.Description ?? value.ToString();
    }

    /// <summary>
    /// Получить значение атрибута указанного типа.
    /// Если указанный атрибут отсутствует, будет возвращено значение "null".
    /// </summary>
    /// <typeparam name="T">Тип атрибута. </typeparam>
    /// <param name="value">Значение перечисления.</param>
    /// <returns>Значение атрибута.</returns>
    private static T? GetAttribute<T>(this Enum value)
        where T : Attribute
    {
        var memberInfos = value.GetType().GetMember(value.ToString());

        if (!memberInfos.Any())
        {
            return null;
        }

        var attributes = memberInfos[0].GetCustomAttributes(typeof(T), false);

        return attributes.Any()
            ? (T)attributes[0]
            : null;
    }
}
