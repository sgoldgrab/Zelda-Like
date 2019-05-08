using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComboSkill : Skill
{

    void Update()
    {
        if (skillIsActive && enemyState.enemyCanUseSkill)
        {
            EnemyBehavior();
        }
    }

    public override void EnemyBehavior()
    {
        //
    }

    public override void AbilityAnimMethod()
    {
        base.AbilityAnimMethod();
    }
}
