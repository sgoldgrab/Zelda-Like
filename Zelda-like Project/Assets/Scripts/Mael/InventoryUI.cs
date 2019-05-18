using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Image image;

    private Sprite sprite;

    private AltarTestSandbox altar;

    [SerializeField] private int altarIndex;

    private void Start()
    {
        altar = GameObject.Find("Altar" + (altarIndex).ToString()).GetComponent<AltarTestSandbox>();
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (altar.chose)
        {
            sprite = altar.chosenSephSprite;
            image.sprite = sprite;
        }
    }
}
