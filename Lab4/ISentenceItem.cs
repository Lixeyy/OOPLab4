namespace Lab4;

/// <summary>
/// Елемент речення (слово або роздільник).
/// </summary>
public interface ISentenceItem
{
    /// <summary>
    /// Повертає текстове значення елемента.
    /// </summary>
    /// <returns>Рядок із вмістом.</returns>
    public string GetStringValue();
}