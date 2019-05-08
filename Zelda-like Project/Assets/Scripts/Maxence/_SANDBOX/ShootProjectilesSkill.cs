using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectilesSkill : CombatSkill
{
    [SerializeField] private GameObject fireBall;

    public override void EnemyBehavior()
    {
        base.EnemyBehavior();
    }

    public override void AdditionalBehavior()
    {
        base.AdditionalBehavior();
    }

    public override void AbilityAnimMethod() // FireBall
    {
        GameObject bullet = Instantiate(fireBall, transform.position, transform.rotation);
        bullet.GetComponent<FireBall>().SetPlayerPos(enemyState.playerTransform.position);

        base.AbilityAnimMethod();
    }
}
