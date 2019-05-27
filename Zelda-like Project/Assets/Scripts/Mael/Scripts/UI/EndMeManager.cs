using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EndMeManager : MonoBehaviour
{
    public TextMeshProUGUI textTuto;
    public GameObject textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public EventSystem eventSystem;

    public GameObject endTextButton;

    private void Start()
    {
        StartCoroutine(Type());
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        

        if (player.gameObject.tag == "Player")
        {
            textDisplay.SetActive(true);
            eventSystem.SetSelectedGameObject(endTextButton.gameObject);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textTuto.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void Update()
    {
        if (textTuto.text == sentences[index])
        {
            endTextButton.SetActive(true);
        }
    }

    public void NextSentence()
    {
        Destroy(textDisplay);
        Destroy(gameObject);
    }
}
