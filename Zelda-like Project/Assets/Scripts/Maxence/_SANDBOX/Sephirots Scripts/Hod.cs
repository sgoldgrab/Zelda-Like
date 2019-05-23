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

    public override void Activation()
    {
        if (isActive && !effect)
        {
            EnemyState.whenEnemyDies += Regen;
            effect = true;
        }

        base.Activation();
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
