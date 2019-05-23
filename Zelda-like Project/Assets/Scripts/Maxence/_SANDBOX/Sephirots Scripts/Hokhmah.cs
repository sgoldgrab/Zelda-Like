using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hokhmah : Sephiroth
{
    private GameObject player;
    private PlayerAbilities playerAbilities;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        playerAbilities = player.GetComponent<PlayerAbilities>();
    }

    public override void Activation()
    {
        if (isActive && !effect)
        {
            playerAbilities.reduction += 0.2f;
            effect = true;
        }

        base.Activation();
    }
}
