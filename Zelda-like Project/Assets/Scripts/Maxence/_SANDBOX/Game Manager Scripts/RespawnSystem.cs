using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RespawnSystem : MonoBehaviour
{
    public GameObject deathMenu;
    public EventSystem eventSystem;
    public Button firstButtonDeath;

    private PlayerState playerState;

    private bool inDeathMenu = false;

    private void Awake()
    {
        playerState = GameObject.Find("PLAYER").GetComponent<PlayerState>();
    }

    private void Update()
    {
        if (playerState.health <= 0 && !inDeathMenu)
        {
            playerState.inMenu = true;
            deathMenu.SetActive(true);
            eventSystem.SetSelectedGameObject(firstButtonDeath.gameObject);

            inDeathMenu = true;
        }

        /*
        if (pausedGame && Input.GetButtonDown("Respawn"))
        {
            Debug.Log("RESPAWN");
            ReloadScene();
        }
        */
    }

    public void ReloadScene()
    {
        deathMenu.SetActive(false);
        playerState.inMenu = false;
        inDeathMenu = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
