using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject gameController;

    private bool hasChecked = false;

    private void OnTriggerEnter2D(Collider2D player)
    {
        
        if(player.CompareTag("PLAYER") && !hasChecked)
        {

            PlayerDeath deathScript = gameController.GetComponent<PlayerDeath>();

            deathScript.checkPoint = true;

            deathScript.checkPointSpawn = this.gameObject;

            hasChecked = true;

        }

    }

}
