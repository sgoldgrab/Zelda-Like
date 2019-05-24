using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathDisplay;
    public EventSystem eventSys;
    public Button tryAgainButton;

    public Button firstSelectedYes;
    public GameObject wannaQuit;

    public bool isDead; //jsp si vous avez déjà une bool pour savoir si le joueur est dead ou pas


    private void Start()
    {
        isDead = false;
        eventSys.SetSelectedGameObject(tryAgainButton.gameObject);
    }

    /*void Update()
    {
        if (player is dead)
        {
            Time.timeScale = 0f;
            deathDisplay.SetActive(true);
            eventSys.SetSelectedGameObject(tryAgainButton.gameObject);
        }
    }*/

    public void Revive()
    {
        //le load a son precedent checkpoint

        deathDisplay.SetActive(false);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        wannaQuit.SetActive(true);
        eventSys.SetSelectedGameObject(firstSelectedYes.gameObject);
    }

    public void QuitGameVEVO()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void NoIStay()
    {
        wannaQuit.SetActive(false);
    }
}
