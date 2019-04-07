using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{

    #region Variables
    private Inventory inventoryScript;

    public PlayerStats statsScript;

    public Health healthScript;


    #endregion

    private void OnTriggerEnter2D(Collider2D player)
    {
        
        if(player.CompareTag("Player"))
        {

            inventoryScript = player.GetComponent<Inventory>();

            statsScript = player.GetComponent<PlayerStatistics>().otherStats;

            healthScript = player.GetComponent<PlayerStatistics>().healthStats;

            for(int i = 0; i <= inventoryScript.currentSlotsTaken; i++)
            {

                inventoryScript.consumables[inventoryScript.currentSlotsTaken] = this.gameObject;

            }

            inventoryScript.currentSlotsTaken++;

            SpriteRenderer sprite = GetComponent<SpriteRenderer>();

            BoxCollider2D collider = GetComponent<BoxCollider2D>();

            collider.enabled = false;

            sprite.enabled = false;

        }

    }

    public virtual void ConsumableUse()
    {


    }

}
