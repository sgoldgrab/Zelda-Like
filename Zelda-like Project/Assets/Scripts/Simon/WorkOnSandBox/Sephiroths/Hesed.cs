using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hesed : AllSephiroths
{
    private GameObject player;
    private PlayerAbilities playerAbilities;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        playerAbilities = GetComponent<PlayerAbilities>();
    }

    private void Update()
    {
        if (isActive)
        {
            EnemyState.whenEnemyHit += CDReduc;
        }
    }

    private void CDReduc()
    {
        playerAbilities.cooldownTime[0] -= 1f;
        playerAbilities.cooldownTime[1] -= 1f;
        playerAbilities.cooldownTime[2] -= 1f;
        playerAbilities.cooldownTime[3] -= 1f;
        playerAbilities.cooldownTime[4] -= 1f;
        playerAbilities.cooldownTime[5] -= 1f;
    }
}

