using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComboSkill : Skill
{
    [SerializeField] private CombatSkill dashSkill;
    [SerializeField] private CombatSkill attackSkill;

    [SerializeField] private float rangeOfAttack;

    void Update()
    {
        if (skillIsActive && enemyState.enemyCanUseSkill)
        {
            EnemyBehavior();
        }
    }

    public override void EnemyBehavior()
    {
        if (Vector2.Distance(transform.position, enemyState.playerTransform.position) <= rangeOfAttack)
        {


            dashSkill.skillIsActive = true;
        }
    }

    public override void AbilityAnimMethod()
    {
        //
    }
}
