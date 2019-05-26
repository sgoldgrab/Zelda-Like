﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public abstract class PickUp : MonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    public GameObject player { get; protected set; }

    private int pickUpSlot;

    public bool used { get; set; }

    protected bool displayed;
    [SerializeField] private List<GameObject> UISlots;
    [SerializeField] private List<GameObject> InventorySlots;
    [SerializeField] private List<GameObject> Texts;

    [TextArea(3,10)]
    [SerializeField] private string textToDisplay;

    public Sprite blankSprite;

    void Awake()
    {
        for (int g = 0; g < 3; g++) UISlots.Add(GameObject.Find("Consumable " + (g + 1).ToString() + " (1)"));

        for (int w = 0; w < 3; w++) InventorySlots.Add(GameObject.Find("Consumable " + (w + 1).ToString()));

        for (int h = 0; h < 3; h++) Texts.Add(GameObject.Find("Text Slot " + (h + 1).ToString()));
    }

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

                DisplayConsumable();
            }
        }
    }

    public void DisplayConsumable()
    {
        if (!displayed)
        {
            UISlots[pickUpSlot].GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
            InventorySlots[pickUpSlot].GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
            Texts[pickUpSlot].GetComponent<TextMeshProUGUI>().text = textToDisplay;

            displayed = true;
        }
    }

    public virtual void Consume()
    {
        UISlots[pickUpSlot].GetComponent<SpriteRenderer>().sprite = blankSprite;
        InventorySlots[pickUpSlot].GetComponent<SpriteRenderer>().sprite = blankSprite;
        Texts[pickUpSlot].GetComponent<TextMeshProUGUI>().text = " ";

        inventory.consumables[pickUpSlot] = null;

        inventory.currentSlotsTaken--;
    }
}

public class Inventory : MonoBehaviour
{
    public int currentSlotsTaken { get; set; }
    public int firstAvailable { get; set; }
    public GameObject[] consumables;
    //[SerializeField] private string consumeInputName;

    [SerializeField] private GameObject inventoryUI;
    private bool displayed;

    public bool canUseConsumable { get; set; } = true;

    public bool hasKey { get; set; } = false;


    void Awake()
    {
        consumables = new GameObject[3];
    }

    void Start()
    {
        inventoryUI.SetActive(false);
    }

    void Update()
    {
        if (GetComponent<PlayerState>().inMenu) return;

        if (Input.GetButtonDown("Inventory"))
        {
            if (!displayed) { inventoryUI.SetActive(true); displayed = true; }

            else if (displayed) { inventoryUI.SetActive(false); displayed = false; }
        }

        InputManager();

        /*
        for (int z = 0; z < 3; z++)
        {
            //if (Input.GetButtonDown(consumeInputName + (z + 1).ToString()) && canUseConsumable) { UseConsumable(z); }
        }
        */
    }

    void InputManager()
    {
        if (Input.GetAxisRaw("Consume X") == -1.0f)
        {
            UseConsumable(0);
        }

        if (Input.GetAxisRaw("Consume Y") == 1.0f)
        {
            UseConsumable(1);
        }

        if (Input.GetAxisRaw("Consume X") == 1.0f)
        {
            UseConsumable(2);
        }
    }

    public void UseConsumable(int slotNum)
    {
        if (consumables[slotNum] == null) { return; }

        consumables[slotNum].GetComponent<PickUp>().Consume();

        if (firstAvailable > slotNum) { firstAvailable = slotNum; }
    }
}
