using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kether : AllSephiroths
{

    private PlayerAttack playerAttack;

    private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        if(isActive)
        {
            playerAttack.attackDamage += 1;
            isActive = false;
        }
    }
}
