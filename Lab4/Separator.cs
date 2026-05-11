namespace Lab4;

/// <summary>Розділовий знак або пробіл.</summary>
/// <param name="data">Символ роздільника.</param>
public class Separator(char data) : ISentenceItem
{
    /// <summary>Повертає знак як рядок.</summary>
    /// <returns>Символ у вигляді рядка.</returns>
    public string GetStringValue()
    {
        return data.ToString();
    }
}