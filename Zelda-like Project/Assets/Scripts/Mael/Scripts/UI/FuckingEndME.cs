using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FuckingEndME : MonoBehaviour
{
    public GameObject displayFrenchText;
    public GameObject displayEnglishText;

    public GameObject endFrenchDisplayButton;
    public GameObject endEnglishDisplayButton;

 

    public EventSystem eventSystem;

    public GlobalData gdScript;

    

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player" & gdScript.isEnglish)
        {
            displayFrenchText.SetActive(false);
            endFrenchDisplayButton.SetActive(true);
            eventSystem.SetSelectedGameObject(endEnglishDisplayButton.gameObject);
        }

        if (player.gameObject.tag == "Player" & gdScript.isEnglish != true)
        {
            displayFrenchText.SetActive(true);
            endFrenchDisplayButton.SetActive(false);
            eventSystem.SetSelectedGameObject(endEnglishDisplayButton.gameObject);
        }
    }

    public void endFrenchDisplay()
    {
        endFrenchDisplayButton.SetActive(false);
    }

    public void endEnglishDisplay()
    {
        displayFrenchText.SetActive(false);

    }

}
