using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hod : AllSephiroths
{
    private GameObject player;
    private PlayerState playerState;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        playerState = GetComponent<PlayerState>();
    }

    private void Update()
    {
        if (isActive)
        {
            EnemyState.whenEnemyDies += Regen;
        }
    }

    private void OnDisable()
    {
        EnemyState.whenEnemyDies -= Regen();
    }

    private void Regen()
    {
        playerState.TakeHeal(1);
    }
}
