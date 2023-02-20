
/* Modification non fusionnée à partir du projet 'Assembly-CSharp.Player'
Avant :
using System.Collections;
Après :
using System;
using System.Collections;
*/
using
/* Modification non fusionnée à partir du projet 'Assembly-CSharp.Player'
Avant :
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
Après :
using TMPro;
using UnityEngine;
using UnityEngine.UI;
*/
UnityEngine;

public class PenduInput : MonoBehaviour
{
    public bool win = false;
    public string letter;
    public string alphabet;
    public int erreurs;
    public string falseLetter;
    public Animator error;
    public PenduText text;
    public PenduGame input;
    public PenduMots mot;


    public void UpdateInput()
    {
        // Restart
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }

        // Détection des inputs
        if (Input.anyKeyDown)
        {
            letter = Input.inputString;
            letter = letter.ToLower();
            Debug.Log(letter);

            // Si la lettre n'est pas dans le mot le joueur augmente son compteur d'erreur de 1 et si ce n'est pas une lettre de l'alphabet un message le signale au joueur
            if (mot.motChoisi.Contains(letter) == false)
            {
                if (alphabet.Contains(letter) && erreurs < 7)
                {
                    erreurs++;
                    falseLetter += letter;
                    error.SetTrigger("False");
                }
                else
                {
                    text.DisplayErrorLetter(letter);
                }
            }
            text.DisplayWrongLetters(falseLetter);
        }
    }
}
