using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public bool checkPoint = false;
    public bool canRespawn = false;
    private bool pausedGame = false;

    private PlayerState playerState;

    public GameObject checkPointSpawn;

    private GameObject player;
    private PlayerDeath playerDeath;

    public GameObject[] savedSephs = new GameObject[4];

    private void Awake()
    {
        if (playerDeath == null)
        {
            DontDestroyOnLoad(gameObject);
            playerDeath = this;
        }

        else if (playerDeath != this) Destroy(gameObject);

        player = GameObject.Find("PLAYER");
        playerState = player.GetComponent<PlayerState>();
    }

    private void Update()
    {
        if (playerState.playerIsDead) OnDeath();

        if (Input.GetKeyDown(KeyCode.K)) playerState.TakeDamage(7);

        if (pausedGame && Input.GetKeyDown(KeyCode.R)) PlayerRespawn();
    }

    private void OnDeath()
    {
        Time.timeScale = 0f;
        pausedGame = true;
    }

    private void PlayerRespawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

        if(checkPoint && canRespawn)
        {
            player.transform.position = checkPointSpawn.transform.position;
        }

        if(!checkPoint && canRespawn)
        {
            player.transform.position = new Vector3(0, 0, 0);
        }

        for(int i = 0; i < savedSephs.Length; i++)
        {
            if (savedSephs[i] != null) savedSephs[i].GetComponent<Sephiroth>().isActive = true;
        }

        Time.timeScale = 1f;
        pausedGame = false;
        playerState.playerIsDead = false;
    }
}

