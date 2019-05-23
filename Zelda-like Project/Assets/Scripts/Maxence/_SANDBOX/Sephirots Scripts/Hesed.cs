﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hesed : Sephiroth
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
            EnemyState.whenEnemyHit += CDReduc;
            effect = true;
        }

        base.Activation();
    }

    private void OnDisable()
    {
        EnemyState.whenEnemyHit -= CDReduc;
    }

    private void CDReduc()
    {
        for (int pute = 0; pute < 6; pute++) playerAbilities.coolDownTime[pute] -= 1f;
    }
}

