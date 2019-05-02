using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binah : AllSephiroths
{

    private PlayerSight playerSight;

    private void Awake()
    {
        playerSight = GetComponent<PlayerSight>();
    }

    private void Update()
    {
        if(isActive)
        {
            playerSight.sightZoneRadius += 1;
            isActive = false;
        }
    }
}
