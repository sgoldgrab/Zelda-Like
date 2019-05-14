using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hod : Sephiroth
{
    private GameObject player;
    private PlayerState playerState;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        playerState = player.GetComponent<PlayerState>();
    }

    private void Update()
    {
        if (isActive)
        {
            EnemyState.whenEnemyDies += Regen;
            isActive = false;
        }
    }

    private void OnDisable()
    {
        EnemyState.whenEnemyDies -= Regen;
    }

    private void Regen()
    {
        playerState.TakeHeal(1);
    }
}
