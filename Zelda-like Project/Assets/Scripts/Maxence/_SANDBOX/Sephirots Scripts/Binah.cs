using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binah : Sephiroth
{
    private bool effect = false;

    private GameObject player;
    private PlayerSight playerSight;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        playerSight = player.GetComponent<PlayerSight>();
    }

    private void Update()
    {
        if(isActive && !effect)
        {
            playerSight.sightZoneRadius += 1;
            effect = true;
        }
    }
}
