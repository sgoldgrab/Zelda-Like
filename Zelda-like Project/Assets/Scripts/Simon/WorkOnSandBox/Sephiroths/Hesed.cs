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
        //réduire les CD en cours de 1 sec
    }
}

