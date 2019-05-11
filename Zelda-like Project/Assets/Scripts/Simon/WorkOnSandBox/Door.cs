using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private GameObject player;
    private PlayerInteraction playerInteraction;
    private Inventory inventory;

    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        playerInteraction = player.GetComponent<PlayerInteraction>();
        inventory = player.GetComponent<Inventory>();

        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public override void InteractionItem()
    {
        if (playerInteraction.isInRangeToInteract && inventory.hasKey)
        {
            boxCollider2D.enabled = false;
            inventory.hasKey = false;
        }
    }
}

