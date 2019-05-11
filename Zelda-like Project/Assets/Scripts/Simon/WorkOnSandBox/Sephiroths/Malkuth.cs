using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malkuth : AllSephiroths
{
    private bool effect = false;

    private GameObject gameManager;
    private PlayerDeath playerDeath;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager");
        playerDeath = gameManager.GetComponent<PlayerDeath>();
    }

    private void Update()
    {
        if(isActive && !effect)
        {
            playerDeath.canRespawn = true;
        }
    }
}
