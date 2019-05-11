using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gevurah : AllSephiroths
{
    private bool effect = false;

    private GameObject player;
    private EntityState entityState;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        entityState = GetComponent<EntityState>();
    }

    private void Update()
    {
        if(isActive && !effect)
        {
            entityState.SetMaxHealth += 1;
            effect = true;
        }
    }
}
