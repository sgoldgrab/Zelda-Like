using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInventaire : MonoBehaviour
{
    public GameObject inventaire;

    public GameObject slotSephi1;

    [SerializeField]
    private TestArray toArray;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            inventaire.SetActive(true);
        }

        
    }
}
