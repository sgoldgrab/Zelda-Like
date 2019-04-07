using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Variables
    public GameObject[] consumables;

    public int currentSlotsTaken = 0;
    #endregion

    private void Awake()
    {

        consumables = new GameObject[3];

    }

    public void UseConsumable(int slotNumber)
    {

        if(consumables[slotNumber] == null) { return; }

        else
        {

            PickUpScript puScript = consumables[slotNumber].GetComponent<PickUpScript>();

            if(puScript == null) { return; }

            else
            {

                puScript.ConsumableUse();

            }

        }

    }

}
