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
        
            
            if(inventoryScript.currentSlotsTaken < inventoryScript.consumables.Length)
            {

                inventoryScript.consumables[inventoryScript.firstAvailable] = gameObject;
                
                //inventoryScript.consumables[inventoryScript.currentSlotsTaken] = gameObject; //NOPE

                inventoryScript.currentSlotsTaken++;
                inventoryScript.firstAvailable++;

                SpriteRenderer sprite = GetComponent<SpriteRenderer>();

                BoxCollider2D collider = GetComponent<BoxCollider2D>();

                collider.enabled = false;

                sprite.enabled = false;

            }
            

        }

    }

    public virtual void ConsumableUse()
    {

        inventoryScript.currentSlotsTaken--;

    }

}
