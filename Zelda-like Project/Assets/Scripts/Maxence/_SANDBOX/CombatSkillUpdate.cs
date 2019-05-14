using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CombatSkillInfos
{
    public int attackRate;
    public float waitTime;

    public int abilityRate;
    public float abilityTime;
    public float abilityDuration;
}

public class CombatSkillUpdate : Trigger
{
    [SerializeField] private List<CombatSkillInfos> combatInfos;

    //ANIM LOOP
    protected int rate;
    protected float wait;

    protected bool isPlaying;

    //EXECUTE LOOP
    protected int abRate;
    protected float abWait;
    protected float abDuration;

    protected bool execute;

    //LATE EFFECT
    protected bool activation;

    void Start()
    {
        rate = combatInfos[0].attackRate;
        abRate = combatInfos[0].abilityRate;
    }

    void Update()
    {
        if (skillIsActive && enemyState.enemyCanUseSkill || triggerIsActive)
        {
            Skill(0);
        }
    }

    public void Skill(int index)
    {
        SkillUpdate(index); // execution of the animation

        if (execute) ExecuteSkill(index); // execution of the main method --> execute the Direct Effect method and allows for the Late Effect method

        if (activation) LateEffect(); // activation of the effect if any
    }

    public virtual void SkillUpdate(int uIndex)
    {
        if (rate > 0)
        {
            if (wait <= 0.0f && !isPlaying) { enemyAnims.SkillAnim(animIndex); isPlaying = true; }

            wait -= Time.deltaTime;
        }

        else
        {
            rate = combatInfos[uIndex].attackRate;
            skillIsActive = false;
            triggerIsActive = false;
            enemyState.enemyCanMove = true;
        }
    }

    public virtual void ExecuteSkill(int eIndex)
    {
        if (abRate > 0)
        {
            if (abWait <= 0.0f)
            {
                DirectEffect();
                abWait = combatInfos[eIndex].abilityTime;
                abRate--;
                abDuration = combatInfos[eIndex].abilityDuration; // only late effects (movements generally)
            }

            abWait -= Time.deltaTime;
        }

        else
        {
            abRate = combatInfos[eIndex].abilityRate;
            execute = false;
            isPlaying = false;
            wait = combatInfos[eIndex].waitTime;
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
        if (abDuration <= 0.0f) activation = false;

        else abDuration -= Time.deltaTime;
    }

    public override void AbilityAnimMethod()
    {
        execute = true;
    }

    public override void EnemyBehavior()
    {
        //
    }
}
