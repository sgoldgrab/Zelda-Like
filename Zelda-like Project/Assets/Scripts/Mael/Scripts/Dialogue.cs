using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject Dialogue1SettingItFalse;
    public GameObject nextButton;
    public GameObject backgroundTexte;



    private void Start()
    {
        Dialogue1SettingItFalse.SetActive(false);
    }

    public void Dialogue1()
    {
        StartCoroutine(Type());
        Dialogue1SettingItFalse.SetActive(true);
    }


    IEnumerator Type()
    {
        Debug.Log("Euh gros ça va?");
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            nextButton.SetActive(true);
        }
    }

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
}

