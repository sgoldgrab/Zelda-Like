using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectilesSkill : CombatSkillNew
{
    [SerializeField] private GameObject fireBall;

    public override void EnemyBehavior()
    {
        base.EnemyBehavior();
    }

    public override void DirectEffect()
    {
        GameObject bullet = Instantiate(fireBall, transform.position, transform.rotation);
        bullet.GetComponent<FireBall>().SetPlayerPos(enemyState.playerTransform.position);

        base.DirectEffect();
    }

    public override void AbilityAnimMethod()
    {
        base.AbilityAnimMethod();
    }
}
