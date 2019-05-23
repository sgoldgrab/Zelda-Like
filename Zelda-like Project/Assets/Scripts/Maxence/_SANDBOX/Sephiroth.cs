using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sephiroth : MonoBehaviour
{
    public bool isActive = false;

    public Sprite sephSprite;

    protected bool effect = false;
    private bool displayed = false;

    [SerializeField] private GameObject UISlot;

    void Update()
    {
        Activation();
    }

    public virtual void Activation()
    {
        if (isActive && !displayed)
        {
            UISlot.GetComponent<Image>().sprite = sephSprite;
            displayed = true;
        }
    }
}

