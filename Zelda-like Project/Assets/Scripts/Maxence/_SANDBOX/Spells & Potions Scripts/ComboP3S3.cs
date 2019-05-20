using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP3S3 : MonoBehaviour
{
    //crée une smoke qui rend le joueur insensible ; --> WORKS FINE --> CONFIRMED

    /*
    [TagSelector]
    public string TagFilter = "";

    [TagSelector]
    public string[] TagFilterArray = new string[] { };
    */

    private PlayerState playerState;

    private float timer = 6f;

    void Start()
    {
        playerState = GameObject.Find("PLAYER").GetComponent<PlayerState>();
    }

    private void Update()
    {
        Debug.Log(playerState.immunities + " " + playerState.damageCount);

        timer -= Time.deltaTime;

        if (playerState.damageCount >= 4 || timer <= 0)
        {
            playerState.immunities = Mathf.Clamp(playerState.immunities - 1, 0, 10);
            playerState.damageCount = 0;

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.transform.parent.parent.gameObject;

            playerState = player.GetComponent<PlayerState>();

            playerState.immunities += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerState.immunities = Mathf.Clamp(playerState.immunities - 1, 0, 10);
        }
    }
}
