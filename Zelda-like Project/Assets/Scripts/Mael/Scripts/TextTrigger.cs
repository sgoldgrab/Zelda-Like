using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    public GameObject textePourObjet;
    public GameObject buttonTexte;


    //public bool isTrigger;

    private void Start()
    {
        textePourObjet.SetActive(false);
        buttonTexte.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {           
            buttonTexte.SetActive(true);           
        }
    }

    /*IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        textePourObjet.SetActive(false);
        Debug.Log("Jesus meurt");
    }*/

    public void DisplayText()
    {
        buttonTexte.SetActive(false);
        textePourObjet.SetActive(true);
        if (Input.GetKeyDown("space"))
        {
            textePourObjet.SetActive(false);     //En gros l'idée était que quand le joueur appui sur un bouton ça remet le texte en false
        }
    }

    

    /*private void Update()
    {
        if (isTrigger == true)
        {
            textePourObjet.SetActive(true);
            StartCoroutine("WaitForSec");
            Debug.Log("Naissance de la bible biblique");
        }

    }*/
}
