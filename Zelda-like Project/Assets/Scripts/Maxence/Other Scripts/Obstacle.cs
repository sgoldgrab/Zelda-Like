using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IComparable<Obstacle>
{
    public SpriteRenderer MySpriteRender { get; set; }

    private Color defaultColor;
    private Color fadedColor;

    [SerializeField] private float alphaColor;

    //Comparer le bordel afin de savoir le bon ordre des obstacles // Pour sûr !
    public int CompareTo(Obstacle other)
    {
        if (MySpriteRender.sortingOrder > other.MySpriteRender.sortingOrder)
        {
            return 1;
        }
        else if (MySpriteRender.sortingOrder < other.MySpriteRender.sortingOrder)
        {
            return -1;
        }

        return 0;
    }

    private void Start()
    {
        MySpriteRender = GetComponent<SpriteRenderer>();

        defaultColor = MySpriteRender.color;
        fadedColor = defaultColor;
        fadedColor.a = alphaColor;
    }

    public void FadeOut()
    {
        MySpriteRender.color = fadedColor;
    }

    public void FadeIn()
    {
        MySpriteRender.color = defaultColor;
    }
}    
