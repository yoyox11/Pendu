using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class PenduMots : MonoBehaviour
{
    public PenduGame pGame;
    public string uri = "https://makeyourgame.fun/api/pendu/avoir-un-mot";
    public string motChoisi;
    public int nbLetter;

    [System.Obsolete]
    public void Dictionary()
    {
        StartCoroutine(GetRequest(uri));
    }

    [System.Obsolete]
    // Fonction pour récuperer le mot aléatoire depuis une page internet
    IEnumerator GetRequest(string uri)
    {
        using UnityWebRequest webRequest = UnityWebRequest.Get(uri);
        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
        {
            Debug.LogError(webRequest.error);
        }
        else
        {
            motChoisi = webRequest.downloadHandler.text;
            string[] texte = motChoisi.Split('"');
            motChoisi = texte[7];
            nbLetter = motChoisi.Length;
            pGame.Initialized();  
        }
    }
}


