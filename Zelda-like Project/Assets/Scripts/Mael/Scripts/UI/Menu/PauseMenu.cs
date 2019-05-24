using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public EventSystem eventSyst;
    public Button firstToBeSelected;

    [SerializeField] private PlayerState playerState;

    void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            if (GameIsPaused) Resume();

            else Paused();
        }
    }

    public void Resume()
    {
        playerState.inMenu = false;

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Paused()
    {
        playerState.inMenu = true;

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        eventSyst.SetSelectedGameObject(firstToBeSelected.gameObject);
    }


    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}

