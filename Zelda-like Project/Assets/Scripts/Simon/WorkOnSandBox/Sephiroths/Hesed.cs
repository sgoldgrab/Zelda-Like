using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hesed : AllSephiroths
{

    private PlayerAbilities playerAbilities;

    private void Awake()
    {
        playerAbilities = GetComponent<PlayerAbilities>();
    }

    private void Update()
    {
        if (isActive)
        {
            TestSimonEnemyState.whenEnemyHit += CDReduc;
            isActive = false;
        }
    }

    private void CDReduc()
    {
        //réduire les CD en cours de 1 sec
    }
}

