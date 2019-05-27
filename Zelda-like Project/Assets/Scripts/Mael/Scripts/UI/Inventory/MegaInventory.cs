using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MegaInventory : MonoBehaviour
{
    public EventSystem eveSystem;
    public Button firstSlotSelected;

    public GameObject abilitiesWindow;

    private PlayerMovement playerMovement;

    public bool[] isFull;
    public GameObject[] consoSlots;

    private void Start()
    {
        abilitiesWindow.SetActive(false);
        playerMovement = GameObject.Find("PLAYER").GetComponent<PlayerMovement>();
    }

    public void OpenADisplay()
    {
        abilitiesWindow.SetActive(true);
    }

    public void CloseADisplay()
    {
        abilitiesWindow.SetActive(false);
    }
    

    /*
        Faut ajouter cette ligne dans la fonction qui ouvre l'inventaire:
        eveSystem.SetSelectedGameObject(firstSlotSelected.gameObject);    
        */
    
}
