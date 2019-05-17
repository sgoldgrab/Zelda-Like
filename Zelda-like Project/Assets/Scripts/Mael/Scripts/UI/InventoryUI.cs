using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Image image;

    private Sprite sprite;

    private Altar altar;

    [SerializeField] private int index;

    private void Start()
    {
        altar = GameObject.Find("Altar" + (index).ToString()).GetComponent<Altar>();
        //altar = GameObject.Find("Altar").GetComponent<Altar>();
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (altar.hasBeenFinallyActivatedAfterAllTheseYears)
        {
            sprite = altar.zeSprite;
            image.sprite = sprite;
        }

    }


    
}
