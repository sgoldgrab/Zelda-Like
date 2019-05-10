using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSkillNew : Trigger
{
    //ANIM LOOP
    [SerializeField] protected int attackRate;
    protected int rate;

    [SerializeField] protected float waitTime;
    protected float wait;

    protected bool isPlaying;

    //EXECUTE LOOP
    [SerializeField] protected int abilityRate;
    protected int abRate;

    [SerializeField] protected float abilityTime;
    protected float abWait;

    [SerializeField] protected float abilityDuration;
    protected float duration;

    protected bool execute;

    //LATE EFFECT
    protected bool activation;

    void Start()
    {
        rate = attackRate;
        abRate = abilityRate;
    }

    void Update()
    {
        if (skillIsActive && enemyState.enemyCanUseSkill || triggerIsActive)
        {
            EnemyBehavior();

            if (execute) Execute(); // execution of the main method

            if (activation) LateEffect(); // activation of the effect if any
        }
    }

    public override void EnemyBehavior()
    {
        if (rate > 0)
        {
            if (wait <= 0.0f && !isPlaying) { enemyAnims.SkillAnim(animIndex); isPlaying = true; }

            wait -= Time.deltaTime;
        }

        else
        {
            rate = attackRate;
            skillIsActive = false;
            triggerIsActive = false;
            enemyState.enemyCanMove = true;
        }
    }

    public virtual void Execute()
    {
        if (abRate > 0)
        {
            if (abWait <= 0.0f)
            {
                DirectEffect();
                abWait = abilityTime;
                abRate--;
                duration = abilityDuration; // only late effects (movements generally)
            }

            abWait -= Time.deltaTime;
        }

        else
        {
            abRate = abilityRate;
            execute = false;
            isPlaying = false;
            wait = waitTime;
            rate--;

            abWait = 0.0f;
        }
    }

    public virtual void DirectEffect()
    {
        activation = true;
    }

    public virtual void LateEffect()
    {
        if (duration <= 0.0f) activation = false;

        else duration -= Time.deltaTime;
    }

    public override void AbilityAnimMethod()
    {
        execute = true;
    }
}
