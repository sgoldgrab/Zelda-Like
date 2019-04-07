using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mist : MonoBehaviour
{

    #region Variables
    private PlayerStance stancesScript;

    private PlayerStats statsScript;
    #endregion

    private void OnTriggerEnter2D(Collider2D player)
    {
        
        if(player.CompareTag("Player"))
        {

            stancesScript = player.GetComponent<PlayerStance>();

            statsScript = player.GetComponent<PlayerStatistics>().otherStats;

            stancesScript.switchIsPossible = false;

            statsScript.movementSpeed *= 0.7f;

        }

    }

    private void OnTriggerExit2D(Collider2D player)
    {
        
        if(player.CompareTag("Player"))
        {

            stancesScript.switchIsPossible = true;

            statsScript.movementSpeed /= 0.7f;

        }

    }

}
