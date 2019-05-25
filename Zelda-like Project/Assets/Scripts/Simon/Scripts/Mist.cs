using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mist : MonoBehaviour
{

    #region Variables
    private PlayerStance stancesScript;

    private PlayerMovement movemenentScript;
    #endregion

    private void OnTriggerEnter2D(Collider2D player)
    {
        
        if(player.CompareTag("Player"))
        {
            Debug.Log("OIUI");

            stancesScript = player.GetComponentInParent<PlayerStance>();

            movemenentScript = player.GetComponentInParent<PlayerMovement>();

            stancesScript.canSwitch = false;

            movemenentScript.playerSpeed *= 0.7f;

        }

    }

    private void OnTriggerExit2D(Collider2D player)
    {
        
        if(player.CompareTag("Player"))
        {

            stancesScript.canSwitch = true;

            movemenentScript.playerSpeed /= 0.7f;

        }

    }

}
