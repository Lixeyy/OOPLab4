namespace Lab4;

/// <summary>Слово, що складається з літер.</summary>
public class Word : ISentenceItem
{
    private readonly Letter[] _letters;

    /// <summary>Створює слово з рядка.</summary>
    /// <param name="word">Текст слова.</param>
    public Word(string word)
    {
        _letters = new Letter[word.Length];
        for (var i = 0; i < word.Length; i++)
        {
            _letters[i] = new Letter(word[i]);
        }
    }

    /// <summary>Повертає слово як рядок.</summary>
    /// <returns>Текст слова.</returns>
    public string GetStringValue()
    {
        var charLetters = new char[_letters.Length];
        for (var i = 0; i < _letters.Length; i++)
        {
            charLetters[i] = _letters[i].Data;
        }
        return new string(charLetters);
    }
}