using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComboSkill : Skill
{
    [SerializeField] private CombatSkillUpdate dashSkill;
    [SerializeField] private CombatSkillUpdate attackSkill;

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
        if (Vector2.Distance(transform.position, enemyState.playerTransform.position) >= rangeOfAttack) dashSkill.Skill(1);

        else if (Vector2.Distance(transform.position, enemyState.playerTransform.position) <= rangeOfAttack) attackSkill.Skill(1);
    }

    public override void AbilityAnimMethod()
    {
        //
    }
}
