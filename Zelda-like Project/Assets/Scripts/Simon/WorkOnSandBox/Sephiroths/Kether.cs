using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kether : AllSephiroths
{
    private bool effect = false;

    private GameObject player;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        if(isActive && !effect)
        {
            playerAttack.attackDamage += 1;
            effect = true;
        }
    }
}
