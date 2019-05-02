using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hod : AllSephiroths
{

    private PlayerState playerState;

    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
    }

    private void Update()
    {
        if (isActive)
        {
            TestSimonEnemyState.whenEnemyHit += Regen;
            isActive = false;
        }
    }

    private void Regen()
    {
        playerState.TakeHeal(1);
    }
}
