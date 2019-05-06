﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class PickUp : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    public GameObject player { get; private set; }

    private int pickUpSlot;

    public bool used { get; set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform.parent.parent.gameObject;

            inventory = player.GetComponent<Inventory>();

            if (inventory.currentSlotsTaken < inventory.consumables.Length)
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

    public virtual void Consume()
    {
        inventory.currentSlotsTaken--;
        used = true;
    }

    public virtual void OnDisable()
    {
        inventory.pressed = false;
    }
}

public class Inventory : MonoBehaviour
{
    public int currentSlotsTaken { get; set; }
    public int firstAvailable { get; set; }
    public GameObject[] consumables;
    [SerializeField] private string consumeInputName;

    public bool pressed;

    public bool canUseConsumable { get; set; } = true;

    void Awake()
    {
        consumables = new GameObject[3];
    }

    void Update()
    {
        if (Input.GetAxisRaw("Consume Y") == 1.0f && !pressed)
        {
            UseConsumable(0);
            pressed = true;
        }

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
