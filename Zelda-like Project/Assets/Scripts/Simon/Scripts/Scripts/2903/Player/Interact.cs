    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    #region Variables
    private InteractableItem itemScript;

    public bool isInRangeToInteract = false;
    #endregion

    private void OnTriggerEnter2D(Collider2D interactable)
    {
        
        if(interactable.CompareTag("Interactable"))
        {

            isInRangeToInteract = true;

            itemScript = interactable.GetComponent<InteractableItem>();

        }

    }

    private void OnTriggerExit2D(Collider2D interactable)
    {
        
        if(interactable.CompareTag("Interactable"))
        {

            isInRangeToInteract = false;

        }

    }

    public void Interaction()
    {

        itemScript.InteractionItem();

    }

}
