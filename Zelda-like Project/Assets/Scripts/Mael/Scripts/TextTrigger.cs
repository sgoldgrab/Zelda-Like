using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextTrigger : MonoBehaviour
{
    public GameObject textePourObjet;
    public GameObject PressTheRightOne;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject Dialogue1SettingItFalse;
    public GameObject nextButton;
    public GameObject backgroundTexte;


    public bool isTrigger;

    private void Start()
    {
        textePourObjet.SetActive(false);
        PressTheRightOne.SetActive(false);
        isTrigger = false;

        Dialogue1SettingItFalse.SetActive(false);
    }
    
    private void OnTriggerStay2D(Collider2D player)
    {
        Debug.Log("help me stp");
        if (player.gameObject.tag == "Player")
        {
            PressTheRightOne.SetActive(true);
            isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            PressTheRightOne.SetActive(false);
            isTrigger = true;
        }
    }




    IEnumerator Type()
    {
        Debug.Log("Euh gros ça va?");
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    /*private void Update()
    {

        if (isTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                PressTheRightOne.SetActive(false);
                StartCoroutine(Type());
                Dialogue1SettingItFalse.SetActive(true);
            }
        }


        if (textDisplay.text == sentences[index])
        {
            nextButton.SetActive(true);
        }
    }*/

    public void NextSentence()
    {
        Debug.Log("NEXT SENTENCE HAHA");
        nextButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            nextButton.SetActive(false);
            backgroundTexte.SetActive(false);
        }
    }

    /*IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        textePourObjet.SetActive(false);
        Debug.Log("Jesus meurt");
    }

    public void DisplayText()
    {
        PressTheRightOne.SetActive(false);
        textePourObjet.SetActive(true);
        if (Input.GetKeyDown("space"))
        {
            textePourObjet.SetActive(false);     //En gros l'idée était que quand le joueur appui sur un bouton ça remet le texte en false
        }
    }

    

    private void Update()
    {
        if (isTrigger == true)
        {
            textePourObjet.SetActive(true);
            StartCoroutine("WaitForSec");
            Debug.Log("Naissance de la bible biblique");
        }

    }*/
}
