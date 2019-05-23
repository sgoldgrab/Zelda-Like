using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binah : Sephiroth
{
    private GameObject player;
    private PlayerSight playerSight;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        playerSight = player.GetComponent<PlayerSight>();
    }

    public override void Activation()
    {
        if(isActive && !effect)
        {
            playerSight.aware = true;
            effect = true;
        }

        base.Activation();
    }
}
