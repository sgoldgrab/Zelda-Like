using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSkill : Trigger
{
    [SerializeField] protected int attackRate;
    protected int rate;

    [SerializeField] protected float waitTime;
    protected float wait;

    [SerializeField] protected float abilityDuration;
    protected float duration;

    protected bool activated;

    void Start()
    {
        rate = attackRate;
    }

    void Update()
    {
        if (skillIsActive && enemyState.enemyCanUseSkill || triggerIsActive)
        {
            EnemyBehavior();

            if (activated) AdditionalBehavior();
        }
    }

    public override void EnemyBehavior()
    {
        if (rate > 0)
        {
            if (wait <= 0.0f)
            {
                enemyAnims.SkillAnim(animIndex);
                wait = waitTime;

                activated = true;
                duration = abilityDuration;
            }

            else
            {
                wait -= Time.deltaTime;
            }
        }

        else
        {
            rate = attackRate;
            skillIsActive = false;
            triggerIsActive = false;
            enemyState.enemyCanMove = true;
        }
    }

    public virtual void AdditionalBehavior()
    {
        if (duration <= 0.0f) activated = false;

        else duration -= Time.deltaTime;
    }

    public override void AbilityAnimMethod()
    {
        rate--;
    }
}
