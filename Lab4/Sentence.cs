namespace Lab4;

/// <summary>Речення зі слів та розділових знаків.</summary>
public class Sentence
{
    private readonly ISentenceItem[] _sentenceItems;

    /// <summary>Кількість слів у реченні.</summary>
    public int WordsCount
    {
        get
        {
            var count = 0;
            foreach (var item in _sentenceItems)
            {
                if (item is Word)
                {
                    count++;
                }
            }
            return count;
        }
    }

    /// <summary>Створює речення з рядка.</summary>
    /// <param name="sentence">Рядок речення.</param>
    public Sentence(string sentence)
    {
        _sentenceItems = DivideSentenceIntoWords(sentence);
    }

    /// <summary>Повертає речення як рядок.</summary>
    /// <returns>Текст речення.</returns>
    public override string ToString()
    {
        var result = "";
        foreach (var item in _sentenceItems)
        {
            result += item.GetStringValue();
        }
        return result;
    }

    private static ISentenceItem[] DivideSentenceIntoWords(string sentence)
    {
        var sentenceItems = new List<ISentenceItem>();
        var currIndex = 0;
        var startWordIndex = -1;

        while (currIndex < sentence.Length)
        {
            var currChar = sentence[currIndex];

            if (char.IsWhiteSpace(currChar))
            {
                TryAddWord(sentenceItems, sentence, currIndex, ref startWordIndex);
                sentenceItems.Add(new Separator(' '));
                do
                {
                    currIndex++;
                } while (currIndex < sentence.Length && char.IsWhiteSpace(sentence[currIndex]));
                continue;
            }
            if (char.IsLetterOrDigit(currChar))
            {
                if (startWordIndex == -1)
                {
                    startWordIndex = currIndex;
                }
            }
            else
            {
                TryAddWord(sentenceItems, sentence, currIndex, ref startWordIndex);
                sentenceItems.Add(new Separator(currChar));
            }

            currIndex++;
        }

        TryAddWord(sentenceItems, sentence, currIndex, ref startWordIndex);
        return sentenceItems.ToArray();
    }

    private static void TryAddWord(List<ISentenceItem> sentenceItems, string sentence, int currIndex, ref int startIndex)
    {
        if (startIndex != -1 && startIndex < currIndex)
        { 
            var wordStr = sentence.Substring(startIndex, currIndex - startIndex);
            sentenceItems.Add(new Word(wordStr));
            startIndex = -1;
        }
    }
}