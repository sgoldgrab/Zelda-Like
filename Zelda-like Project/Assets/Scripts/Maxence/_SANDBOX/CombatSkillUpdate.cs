using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CombatInfos
{
    public int attackRate;
    public float waitTime;

    public int abilityRate;
    public float abilityTime;
    public float abilityDuration;
}

public class CombatSkillUpdate : Trigger
{
    [SerializeField] private List<CombatInfos> combatInfos;

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

    //COMPLEX BEHAVIOR REQUIRED
    protected int index;

    void Start()
    {
        rate = combatInfos[0].attackRate;
        abRate = combatInfos[0].abilityRate;
    }

    void Update()
    {
        if (skillIsActive && enemyState.enemyCanUseSkill || triggerIsActive)
        {
            Skill(0); // if the skill is activated the usual way, it plays the methid with the base informations (0)
        }
    }

    public virtual void Skill(int ind)
    {
        index = ind;

        SkillUpdate(); // execution of the animation

        if (execute) ExecuteSkill(); // execution of the main method --> execute the Direct Effect method and allows for the Late Effect method

        if (activation) LateEffect(); // activation of the effect if any
    }

    public virtual void SkillUpdate()
    {
        if (rate > 0)
        {
            if (wait <= 0.0f && !isPlaying) { enemyAnims.SkillAnim(animIndex); isPlaying = true; }

            wait -= Time.deltaTime;
        }

        else
        {
            rate = combatInfos[index].attackRate;
            skillIsActive = false;
            triggerIsActive = false;
            enemyState.enemyCanMove = true;
        }
    }

    public virtual void ExecuteSkill()
    {
        if (abRate > 0)
        {
            if (abWait <= 0.0f)
            {
                DirectEffect();
                abWait = combatInfos[index].abilityTime;
                abRate--;
                abDuration = combatInfos[index].abilityDuration; // only late effects (movements generally)
            }

            abWait -= Time.deltaTime;
        }

        else
        {
            abRate = combatInfos[index].abilityRate;
            execute = false;
            isPlaying = false;
            wait = combatInfos[index].waitTime;
            rate--;

            abWait = 0.0f;
        }
    }

    public virtual void DirectEffect()
    {
        //
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

    public void Reset(string type)
    {
        abWait = 0.0f;
        abRate = combatInfos[index].abilityRate;

        execute = false;
        isPlaying = false;

        wait = combatInfos[index].waitTime;
        rate--;

        if (type == "EndSkill")
        {
            rate = combatInfos[index].attackRate;

            skillIsActive = false;
            triggerIsActive = false;

            enemyState.enemyCanMove = true;
        }
    }

    ////

    public override void EnemyBehavior()
    {
        //
    }
}
