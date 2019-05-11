using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hokhmah : AllSephiroths
{
    private bool effect = false;

    private GameObject player;
    private PlayerAbilities playerAbilities;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        playerAbilities = GetComponent<PlayerAbilities>();
    }

    private void Update()
    {
        if(isActive && !effect)
        {
            playerAbilities.reduction += 0.2;
            effect = true;
        }
    }
}
