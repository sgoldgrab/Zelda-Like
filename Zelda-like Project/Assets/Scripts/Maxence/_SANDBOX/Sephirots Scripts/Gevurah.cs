using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gevurah : Sephiroth
{
    private bool effect = false;

    private GameObject player;
    private EntityState entityState;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        entityState = player.GetComponent<EntityState>();
    }

    private void Update()
    {
        if(isActive && !effect)
        {
            entityState.SetMaximumHealth += 1;
            effect = true;
        }
    }
}
