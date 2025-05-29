// Scripture.cs
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (var word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWord()
    {
        var random = new Random();
        int index;
        do
        {
            index = random.Next(_words.Count);
        } while (_words[index].IsHidden());

        _words[index].Hide();
    }

    public string GetDisplayText()
    {
        var displayText = _reference.GetDisplayText() + "\n";
        foreach (var word in _words)
        {
            displayText += word.GetText() + " ";
        }
        return displayText.Trim();
    }

    public bool AllWordsHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
