using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class PickUp : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    public GameObject player { get; private set; }

    private int pickUpSlot;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<GameObject>();

            inventory = player.GetComponent<Inventory>();

            if (inventory.currentSlotsTaken < inventory.consumables.Count)
            {
                pickUpSlot = inventory.firstAvailable;
                inventory.consumables[pickUpSlot] = gameObject;

                inventory.currentSlotsTaken++;
                inventory.firstAvailable++;

                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    public virtual void Consume() { inventory.currentSlotsTaken--; }
}

public class Inventory : MonoBehaviour
{
    public int currentSlotsTaken { get; set; }
    public int firstAvailable { get; set; }
    public List<GameObject> consumables { get; private set; }
    [SerializeField] private string consumeInputName;

    public bool canUseConsumable { get; set; } = true;

    void Update()
    {
        for (int z = 0; z < 3; z++)
        {
            //if (Input.GetButtonDown(consumeInputName + (z + 1).ToString()) && canUseConsumable) { UseConsumable(z); }
        }
    }

    public void UseConsumable(int slotNum)
    {
        if (consumables[slotNum] == null) { return; }

        consumables[slotNum].GetComponent<PickUp>().Consume();

        if(firstAvailable > slotNum) { firstAvailable = slotNum; }
    }
}
