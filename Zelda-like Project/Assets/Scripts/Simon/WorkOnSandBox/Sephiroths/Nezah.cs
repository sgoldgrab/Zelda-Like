using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nezah : AllSephiroths
{
    private bool effect = false;

    private GameObject player;
    private PlayerAbilities playerAbilities;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        playerAbilities = player.GetComponent<PlayerAbilities>();
    }

    private void Update()
    {
        if(isActive && !effect)
        {
            /* playerAbilities.potionDuration *= 1.3f; */
            effect = true;
        }
    }
}
