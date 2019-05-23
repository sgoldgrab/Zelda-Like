using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yesod : Sephiroth
{
    private GameObject player;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        playerAttack = player.GetComponent<PlayerAttack>();
    }

    public override void Activation()
    {
        if (isActive && !effect)
        {
            //playerAttack.attackSpeed *= 1.5f; --> A faire avec anim rate
            effect = true;
        }

        base.Activation();
    }

}
