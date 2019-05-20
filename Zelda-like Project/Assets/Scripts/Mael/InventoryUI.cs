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
        GameObject altarMessenger = GameObject.Find("Altar" + (altarIndex).ToString());
        if (altarMessenger != null) altar = altarMessenger.GetComponent<AltarTestSandbox>();

        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (altar == null) return;

        if (altar.chose)
        {
            sprite = altar.chosenSephSprite;
            image.sprite = sprite;
        }
    }
}
