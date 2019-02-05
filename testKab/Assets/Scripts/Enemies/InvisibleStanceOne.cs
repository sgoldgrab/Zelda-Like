﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleStanceOne : MonoBehaviour
{

    private SpriteRenderer sprite;

    public GameObject player;
    private Stances playerStance;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        playerStance = player.GetComponent<Stances>();
    }

    private void Update()
    {
        if(playerStance.stanceOne)
        {
            sprite.enabled = false;
        }

        else if(!playerStance.stanceOne)
        {
            sprite.enabled = true;
        }
    }
}
