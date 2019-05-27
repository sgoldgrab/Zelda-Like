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

    private EventSystem eventSystem;

    private GlobalData globalData;

    //Timing
    private bool activated;

    private float timer = 4f;
    private float time;

    void Start()
    {
        time = timer;

        eventSystem = GameObject.Find("EVENTSYSTEM").GetComponent<EventSystem>();

        globalData = GameObject.Find("DATA").GetComponent<GlobalData>();
    }

    void Update()
    {
        if (activated)
        {
            if (time <= 0.0f) { endEnglishDisplay(); endFrenchDisplay(); }

            time -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        activated = true;

        if (player.gameObject.tag == "Player" & globalData.isEnglish) // Display English
        {
            displayEnglishText.SetActive(true);
            eventSystem.SetSelectedGameObject(endEnglishDisplayButton.gameObject);
        }

        if (player.gameObject.tag == "Player" & !globalData.isEnglish) // Display French
        {
            displayFrenchText.SetActive(true);
            eventSystem.SetSelectedGameObject(endFrenchDisplayButton.gameObject);
        }
    }

    public void endFrenchDisplay()
    {
        GetComponent<Collider2D>().enabled = false;
        Destroy(displayFrenchText);
    }

    public void endEnglishDisplay()
    {
        GetComponent<Collider2D>().enabled = false;
        Destroy(displayEnglishText);
    }
}
