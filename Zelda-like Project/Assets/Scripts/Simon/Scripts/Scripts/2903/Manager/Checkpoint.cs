using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    #region Variables
    [SerializeField] private GameObject gameController;

    private bool hasChecked = false;
    #endregion

    private void OnTriggerEnter2D(Collider2D player)
    {
        
        if(player.CompareTag("Player") && !hasChecked)
        {

            /*
            PlayerDeath deathScript = gameController.GetComponent<PlayerDeath>(); GERER LA MORT DU JOUEUR

            deathScript.checkPoint = true;

            deathScript.checkPointSpawn = this.gameObject;

            hasChecked = true;
            */

        }

    }

}
