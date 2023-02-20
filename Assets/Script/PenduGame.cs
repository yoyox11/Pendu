using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PenduGame : MonoBehaviour
{
    [SerializeField] private GameObject _sprite;
    [SerializeField] private GameObject _panelLose;
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private GameObject _false;
    [SerializeField] private Sprite[] _sp;
    [SerializeField] private string _reponse;

    public PenduText pText;
    public PenduMots pMot;
    public PenduInput pInput;

    [System.Obsolete]
    void Awake()
    {
        pMot.Dictionary();
    }

    void Update()
    {
        if (pMot.motChoisi != "")
        {
            pInput.UpdateInput();
            Validation();
        }
    }

    public void Initialized()
    {
        // Mise en place de certaines variables nécessaires pour la suite
        pInput.erreurs = 0;
        pInput.letter = "";
        pInput.alphabet = "abcdefghijklmnopqrstuvwxyz";

        // Texte pré-établi
        pInput.text.DisplayAsk();
        pInput.text.UnderscoreWord(StartUnderscore());
    }

    // Fonction pour définir le nombre de "_" en fonction du mot choisi
    string StartUnderscore()
    {
        string Underscore = "";
        for (int a = 0; a < pMot.nbLetter; a++)
        {
            Underscore += "_";
        }
        return (Underscore);
    }

    // Vérification des lettres du mots pour savoir si elles coincident avec l'input envoyé
    void Validation()
    {
        _reponse = "";
        pInput.win = false;
        int nbLetter = pMot.nbLetter;

        for (int i = 0; i < nbLetter; ++i)
        {
            if (pInput.text.secretWord.text.Substring(i, 1) == "_")
            {
                if (pMot.motChoisi.Substring(i, 1) == pInput.letter)
                {
                    _reponse += pInput.letter;
                    pInput.win = true;
                }
                else
                {
                    _reponse += "_";
                }
            }
            else
            {
                _reponse += pInput.text.secretWord.text.Substring(i, 1);
            }
        }
        pInput.text.secretWord.text = _reponse;
        Verification();
    }

    // Win or Lose
    void Verification()
    {
        if (pInput.text.secretWord.text == pMot.motChoisi)
        {
            _panelWin.SetActive(true);
            _panelWin.GetComponentInChildren<TextMeshProUGUI>().text = "Gagné !" + "\n" + "Le mot étais bien : " + pMot.motChoisi;
            StartCoroutine(Restart());
        }
        else
        {
            _sprite.GetComponent<Image>().sprite = _sp[pInput.erreurs];
            if (pInput.erreurs == 7)
            {
                _panelLose.SetActive(true);
                _panelLose.GetComponentInChildren<TextMeshProUGUI>().text = "Perdu !" + "\n" + "Le mot était " + pMot.motChoisi;
                StartCoroutine(Restart());
            }
        }
    }

    // Restart
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(4f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
