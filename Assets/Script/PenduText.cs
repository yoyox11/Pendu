using TMPro;
using UnityEngine;

public class PenduText : MonoBehaviour
{
    public TextMeshProUGUI ask;
    public TextMeshProUGUI theLetter;
    public TextMeshProUGUI secretWord;
    public PenduMots mot;

    // Fonction pour associer un texte à chaque TextMesh utilisé dans Unity
    public void DisplayWrongLetters(string _falseLetter)
    {
        theLetter.SetText("Erreurs : <color=red>" + _falseLetter + "</color>");
    }

    public void DisplayErrorLetter(string _letter)
    {
        theLetter.SetText(_letter + " n'est pas une lettre.");
    }

    public void DisplayAsk()
    {
        ask.SetText("Donnez moi une lettre");
    }

    public void UnderscoreWord(string Underscore)
    {
        secretWord.SetText(Underscore);
    }
}
