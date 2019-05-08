using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffect : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Player"))
        {

            PlayerControllerEzEz scriptPlayer = other.GetComponent<PlayerControllerEzEz>();

            scriptPlayer.playerSpeed += 1;

        }

        if(other.CompareTag("Templar"))
        {

            Templar scriptEnemy = other.GetComponent<Templar>();

            scriptEnemy.templarSpeed -= 1;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            PlayerControllerEzEz scriptPlayer = other.GetComponent<PlayerControllerEzEz>();

            scriptPlayer.playerSpeed -= 1;

        }

        if (other.CompareTag("Templar"))
        {

            Templar scriptEnemy = other.GetComponent<Templar>();

            scriptEnemy.templarSpeed += 1;

        }
    }

}
