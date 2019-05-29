using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneManagerPop : MonoBehaviour
{
    public string sceneToPlay;

    public GameObject credits;
    public EventSystem eventSys;
    public Button returnButton;
    public Button mainMenuButton;

    private AudioManager audioManager;
    [SerializeField] private string MenuLoopMusic;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        audioManager.PlaySound("MenuLoopMusic");
    }

    public void Game()
    {
        audioManager.StopSound("MenuLoopMusic");

        SceneManager.LoadScene(sceneToPlay);
    }

    public void Option()
    {
        SceneManager.LoadScene("Options");
    }

    public void DisplayCredits()
    {
        credits.SetActive(true);
        eventSys.SetSelectedGameObject(returnButton.gameObject);
    }

    public void DisplayCreditsOff()
    {
        credits.SetActive(false);
        eventSys.SetSelectedGameObject(mainMenuButton.gameObject);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
