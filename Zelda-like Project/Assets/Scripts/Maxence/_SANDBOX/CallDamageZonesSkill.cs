using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDamageZonesSkill : CombatSkill
{
    [SerializeField] private GameObject areaOfEffect;

    public override void EnemyBehavior()
    {
        base.EnemyBehavior();
    }

    public override void AdditionalBehavior()
    {
        base.AdditionalBehavior();
    }

    public override void AbilityAnimMethod()
    {
        Vector2 desiredPos = enemyState.playerTransform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));

        GameObject aOE = Instantiate(areaOfEffect, desiredPos, transform.rotation);

        base.AbilityAnimMethod();
    }
}
