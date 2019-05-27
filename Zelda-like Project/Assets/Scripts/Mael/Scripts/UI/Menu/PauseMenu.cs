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

    public AudioMixer audiMixer;
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseSettingsUI;

    public EventSystem eventSyst;
    public Button firstToBeSelected;
    public Button firstSettingsToBeSelected;

    public GameObject areYouSure;
    public Button yesPleaseBeSelected;

    [SerializeField] private PlayerDash playerDash;

    // Update is called once per frame
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
        playerDash.canDash = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Paused()
    {
        playerDash.canDash = false;
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

    public void LoadSettings()
    {
        pauseSettingsUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        eventSyst.SetSelectedGameObject(firstSettingsToBeSelected.gameObject);
    }

    public void ReturnPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        pauseSettingsUI.SetActive(false);
    }

    public void SetEnglish()
    {
        Localize.SetCurrentLanguage(SystemLanguage.English);
<<<<<<< HEAD
        //GameObject.Find("DATA").GetComponent < GetComponent<GlobalData>().isEnglish = true;
=======
>>>>>>> MaelV2
    }

    public void SetFrench()
    {
        Localize.SetCurrentLanguage(SystemLanguage.French);
<<<<<<< HEAD
        //GameObject.Find("DATA").GetComponent < GetComponent<GlobalData>().isEnglish = false;
=======
>>>>>>> MaelV2
    }

    

    public void SetVolume(float volume)
    {
        audiMixer.SetFloat("MainVolume", volume);
    }

    public void QuitGame()
    {
        
        areYouSure.SetActive(true);
        eventSyst.SetSelectedGameObject(yesPleaseBeSelected.gameObject);
        
    }

    public void YesIQuit()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void NoIStay()
    {
        areYouSure.SetActive(false);
    }

}

