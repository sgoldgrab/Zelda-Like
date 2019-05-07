using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gevurah : AllSephiroths
{
    private bool effect = false;

    private GameObject player;
    private PlayerState playerState;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        playerState = GetComponent<PlayerState>();
    }

    private void Update()
    {
        if(isActive && !effect)
        {
            /*playerState.SetMaximumHealth*/
            effect = true;
        }
    }
}
