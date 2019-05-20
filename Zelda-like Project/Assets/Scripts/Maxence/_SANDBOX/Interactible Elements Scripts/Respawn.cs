using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public static Respawn respawnInstance;

    public bool checkPoint = false;
    public bool canRespawn = true;
    private bool pausedGame = false;

    private GameObject player;
    private PlayerState playerState;

    public GameObject checkPointSpawn;

    public GameObject[] savedSephs = new GameObject[4];

    private void Awake()
    {
        if (respawnInstance == null)
        {
            DontDestroyOnLoad(gameObject);
            respawnInstance = this;
        }

        else if (respawnInstance != this) Destroy(gameObject);

        player = GameObject.Find("PLAYER");

        playerState = player.GetComponent<PlayerState>();
    }

    private void Update()
    {
        if (playerState.health <= 0)
        {
            Debug.Log("DEATH");
            OnDeath();
        }

        if (pausedGame && Input.GetButtonDown("Respawn"))
        {
            Debug.Log("RESPAWN");
            PlayerRespawn();
        }
    }

    private void OnDeath()
    {
        Time.timeScale = 0f;
        pausedGame = true;
    }

    private void PlayerRespawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

        if (checkPoint && canRespawn)
        {
            Debug.Log("A LA MAISON");
            player.transform.position = checkPointSpawn.transform.position;
            player.transform.rotation = Quaternion.identity;
        }

        for (int i = 0; i < savedSephs.Length; i++)
        {
            if (savedSephs[i] != null) savedSephs[i].GetComponent<Sephiroth>().isActive = true;
        }

        Time.timeScale = 1f;
        pausedGame = false;
    }
}
