using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void InteractionItem();
}

public class PlayerInteraction : MonoBehaviour
{
    private Interactable interactable;

    public bool isInRangeToInteract { get; set; } = false;
    [SerializeField] private string interactName;

    public bool canInteract { get; set; }

    void Update()
    {
        if (GetComponent<PlayerState>().inMenu) return;

        if (Input.GetButtonDown(interactName)) { Interaction(); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            isInRangeToInteract = true;
            interactable = other.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            isInRangeToInteract = false;
        }
    }

    public void Interaction()
    {
        if (interactable == null) { return; }

        interactable.InteractionItem();
    }
}
