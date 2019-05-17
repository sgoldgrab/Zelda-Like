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

    private void Update()
    {
        Debug.Log(playerState.immunities + " " + playerState.damageCount);

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            playerState.immunities -= 1;
            playerState.damageCount = 0;

            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.transform.parent.parent.gameObject;

            playerState = player.GetComponent<PlayerState>();

            if (playerState.damageCount < 4)
            {
                playerState.immunities += 1;
            }

            else if (playerState.damageCount >= 4)
            {
                playerState.immunities -= 1;
                playerState.damageCount = 0;

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerState.immunities -= 1;
        }
    }
}
