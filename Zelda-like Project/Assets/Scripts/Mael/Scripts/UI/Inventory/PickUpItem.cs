using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private MegaInventory inventory;
    public GameObject item;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<MegaInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gros il est bientot 3h du mat");
            for (int i = 0; i < inventory.consoSlots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(item, inventory.consoSlots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
