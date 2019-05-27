using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portail : Interactable
{
    private Inventory inventory;

    private BoxCollider2D colliderGrille;

    [SerializeField] private GameObject tuto;

    private void Start()
    {
        inventory = GameObject.Find("PLAYER").GetComponent<Inventory>();
    }

    public override void InteractionItem()
    {
        if(!inventory.hasKey)
        {
            tuto.SetActive(true);
        }

        if (inventory.hasKey)
        {
            colliderGrille = GetComponentInChildren<BoxCollider2D>();
            colliderGrille.enabled = false;

            inventory.hasKey = false;
        }
    }
}
