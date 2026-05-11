namespace Lab4;

/// <summary>Текст, що складається з речень.</summary>
public class Text
{
    private static readonly char[] SentenceSeparators =  ['!', '?', '.'];
    private readonly Sentence[] _sentences;

    /// <summary>Створює текст із рядка.</summary>
    /// <param name="txt">Вхідний рядок.</param>
    public Text(string txt)
    {
        _sentences = DivideIntoSentences(txt);
    }

    /// <summary>Повертає весь текст як рядок.</summary>
    /// <returns>Текст одним рядком.</returns>
    public override string ToString()
    {
        var result = "";
        foreach (var sentence in _sentences)
        {
            result += sentence.ToString() + ' ';
        }
        return result.Trim();
    }

    /// <summary>Повертає речення, відсортовані за кількістю слів (від меншого до більшого).</summary>
    /// <returns>Відсортований масив речень.</returns>
    public Sentence[] GetSortedSentences()
    {
        Sentence[] sortedSentences = [.._sentences];
        Array.Sort(sortedSentences, SentenceComparerByWordsCount);
        return sortedSentences;
    }

    private static Sentence[] DivideIntoSentences(string text)
    {
        var strSentences = text.Split(SentenceSeparators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var result = new Sentence[strSentences.Length];
        var currIndex = 0;

        for (var i = 0; i < strSentences.Length; i++)
        {
            (currIndex, result[i]) = ExtractFullSentence(text, currIndex, strSentences[i]);
        }

        return result;
    }

    private static (int currIndex, Sentence sentence) ExtractFullSentence(string text, int currIndex, string rawSentence)
    {
        var startIndex = text.IndexOf(rawSentence, currIndex, StringComparison.Ordinal);
        var endIndex = startIndex + rawSentence.Length;

        while (endIndex < text.Length && SentenceSeparators.Contains(text[endIndex]))
        {
            endIndex++;
        }

        var wholeSentence = text.Substring(startIndex, endIndex - startIndex);
        var sentenceObj = new Sentence(wholeSentence);

        return (endIndex, sentenceObj);
    }

    private static int SentenceComparerByWordsCount(Sentence sentence1, Sentence sentence2)
    {
        return sentence1.WordsCount.CompareTo(sentence2.WordsCount);
    }
}