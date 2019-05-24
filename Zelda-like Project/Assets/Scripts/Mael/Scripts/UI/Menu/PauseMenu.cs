using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DFTGames.Localization;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [Header("Pause Menu")]
    public GameObject pauseMenuUI;
    public Button firstButtonMenu;

    [Header("Settings Menu")]
    public GameObject pauseSettingsUI;
    public Button firstButtonSettings;

    [Header("Quit Menu")]
    public GameObject quitGameMenuUI;
    public Button firstButtonQuit;

    public EventSystem eventSyst;

    private AudioMixer audioMixer;

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
        pauseSettingsUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Paused()
    {
        playerState.inMenu = true;

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        eventSyst.SetSelectedGameObject(firstButtonMenu.gameObject);
    }

    #region settings
    public void LoadSettings()
    {
        pauseSettingsUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        eventSyst.SetSelectedGameObject(firstButtonSettings.gameObject);
    }

    public void UnloadSettings()
    {
        pauseSettingsUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        eventSyst.SetSelectedGameObject(firstButtonMenu.gameObject);
    }

    public void SetEnglish()
    {
        Localize.SetCurrentLanguage(SystemLanguage.English);
    }

    public void SetFrench()
    {
        Localize.SetCurrentLanguage(SystemLanguage.French);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MainVolume", volume);
    }
    #endregion

    #region quit
    public void QuitToMenu()
    {
        quitGameMenuUI.SetActive(true);
        eventSyst.SetSelectedGameObject(firstButtonQuit.gameObject);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ReturnToGame()
    {
        quitGameMenuUI.SetActive(false);
        eventSyst.SetSelectedGameObject(firstButtonMenu.gameObject);
    }
    #endregion
}

