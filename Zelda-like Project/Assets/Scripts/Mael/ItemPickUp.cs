using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private InventoryUI inventory;

    private void Start()
    {

         inventory = player.GetComponent<InventoryUI>();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print("pické");
            gameObject.SetActive(false);

        }
    }
}

