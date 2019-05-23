using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nezah : Sephiroth
{
    private GameObject player;
    private PotionsEffects potionsEffects;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        potionsEffects = player.GetComponent<PotionsEffects>();
    }

    public override void Activation()
    {
        if(isActive && !effect)
        {
            potionsEffects.bonusCooldown *= 1.3f;
            effect = true;
        }

        base.Activation();
    }
}
