using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void InteractionItem();
}

public class PlayerInteraction : MonoBehaviour
{
    private Interactable itemScript;

    public bool isInRangeToInteract { get; set; } = false;
    [SerializeField] private string interactName;

    void Update()
    {
        if (Input.GetButtonDown(interactName)) { Interaction(); }
    }

    private void OnTriggerEnter2D(Collider2D interactable)
    {
        if (interactable.CompareTag("Interactable"))
        {
            isInRangeToInteract = true;
            itemScript = interactable.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit2D(Collider2D interactable)
    {
        if (interactable.CompareTag("Interactable"))
        {
            isInRangeToInteract = false;
        }
    }

    public void Interaction() { itemScript.InteractionItem(); }
}
