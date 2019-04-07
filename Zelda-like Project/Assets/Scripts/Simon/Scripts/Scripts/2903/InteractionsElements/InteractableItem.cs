using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{

    private Interact interactionScript;

    private void OnTriggerEnter2D(Collider2D player)
    {
        
        if(player.CompareTag("Player"))
        {

            interactionScript = player.GetComponent<Interact>();

            interactionScript.isInRangeToInteract = true;

        }

    }

}
