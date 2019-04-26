using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("Touché");

        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Double Touché");
            buttonTexte.SetActive(true);
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        textePourObjet.SetActive(false);
        Debug.Log("Jesus meurt");
    }

    public void DisplayText()
    {
        textePourObjet.SetActive(true);
        StartCoroutine("WaitForSec");
        Debug.Log("Naissance de la bible");
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
