using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSimonInventory : MonoBehaviour
{
    public int currentSlotsTaken { get; set; }
    public int firstAvailable { get; set; }
    public List<GameObject> consumables { get; private set; }
    [SerializeField] private string consumeInputName;

    public bool canUseConsumable = true;

    void Update()
    {
        for (int z = 0; z < 3; z++)
        {
            if (Input.GetButtonDown(consumeInputName + (z + 1).ToString()) && canUseConsumable) { UseConsumable(z); }
        }
    }

    public void UseConsumable(int slotNum)
    {
        if (consumables[slotNum] == null) { return; }

        consumables[slotNum].GetComponent<PickUp>().Consume();

        if (firstAvailable > slotNum) { firstAvailable = slotNum; }
    }
}
