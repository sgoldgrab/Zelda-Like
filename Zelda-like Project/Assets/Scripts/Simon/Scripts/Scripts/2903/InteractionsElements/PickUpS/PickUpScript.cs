using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{

    #region Variables
    private Inventory inventoryScript;

    public GameObject player;
    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(player.CompareTag("Player"))
        {

            inventoryScript = player.GetComponent<Inventory>();

            player = other.GetComponent<GameObject>();
        
            
            if(inventoryScript.currentSlotsTaken < inventoryScript.consumables.Count)
            {

                inventoryScript.consumables[inventoryScript.firstAvailable] = gameObject;

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
