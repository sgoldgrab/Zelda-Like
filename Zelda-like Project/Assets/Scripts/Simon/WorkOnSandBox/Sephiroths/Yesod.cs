using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yesod : AllSephiroths
{
    private bool effect = false;

    private GameObject player;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        playerAttack = player.GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        if (isActive && !effect)
        {
            playerAttack.attackSpeed *= 1.5f;
            effect = true;
        }
    }

}
