using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PLAYER"))
        {
            sprite.enabled = false;
            boxCollider2D.enabled = false;

            Inventory inventory = other.GetComponent<Inventory>();
            inventory.hasKey = true;
        }
    }

}
