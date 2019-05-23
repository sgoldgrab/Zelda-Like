using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malkuth : Sephiroth
{
    private GameObject gameManager;
    private PlayerDeath playerDeath;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager");
        playerDeath = gameManager.GetComponent<PlayerDeath>();
    }

    public override void Activation()
    {
        if(isActive && !effect)
        {
            playerDeath.canRespawn = true;
            effect = true;
        }

        base.Activation();
    }
}
