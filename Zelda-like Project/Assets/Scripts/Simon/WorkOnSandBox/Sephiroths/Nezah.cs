using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nezah : AllSephiroths
{
    private bool effect = false;

    private GameObject player;
    private PotionsEffects potionsEffects;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        potionsEffects = player.GetComponent<PotionsEffects>();
    }

    private void Update()
    {
        if(isActive && !effect)
        {
            potionsEffects.duration *= 1.3f;
            effect = true;
        }
    }
}
