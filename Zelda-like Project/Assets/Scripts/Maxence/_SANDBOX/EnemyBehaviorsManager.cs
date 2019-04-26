using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Conditions
{
    DistanceToPlayer,
    NumberOfEnemies,
    HasTakenDamage,
    IsAttacked,
    PlayerUseAnAbility,
    PlayerSwitchStance,
    None
}

public abstract class Behavior : MonoBehaviour
{
    public abstract void EnemyBehavior();

    [SerializeField] protected EnemyState enemyState;
}

public abstract class ConditionedBehavior : Behavior
{
    [SerializeField] private List<Conditions> conditions;
    public List<Conditions> conds { get => conditions; protected set => conditions = value; }

    [SerializeField] private List<ConditionInfo> conditionInfos;
    public List<ConditionInfo> infos { get => conditionInfos; protected set => conditionInfos = value; }
}

public abstract class Skill : ConditionedBehavior
{
    public string skillName;

    public abstract void SkillAnimMethod();

    public bool skillIsActive { get; set; } = false;
    public float additionalCooldown { get; set; } = 0.0f;
}

public abstract class Trigger : ConditionedBehavior
{
    public bool triggerIsActive { get; set; } = false;
}

public class EnemyBehaviorsManager : MonoBehaviour
{
    //ENUMS
    public enum Behaviors { idle, combat }
    public Behaviors behavior { get; private set; } = Behaviors.idle;

    //COMPONENTS
    private GameObject player;
    [SerializeField] private string playerName;

    [SerializeField] private EnemyState enemyState;
    [SerializeField] private EnemyConditions enemyConditions;

    [SerializeField] private List<Skill> skills;
    public List<Skill> theSkills { get => skills; private set => skills = value; }

    [SerializeField] private List<Trigger> triggers;

    [SerializeField] private Behavior moveIdleBehavior;
    [SerializeField] private Behavior moveCombatBehavior;

    [SerializeField] private float startGeneralCooldown;
    public float generalCooldown { get; private set; } = 0.0f;
    public int k { get; private set; } = 0;

    void Start()
    {
        player = GameObject.Find(playerName);
    }

    void Update()
    {
        //Debug.Log(generalCooldown);

        if (enemyState.health <= 0) { return; }

        if (behavior == Behaviors.idle)
        {
            moveIdleBehavior.EnemyBehavior();
        }

        else if (behavior == Behaviors.combat && player.GetComponent<PlayerState>().health > 0)
        {
            if (enemyState.enemyCanMove)
            {
                moveCombatBehavior.EnemyBehavior();
            }

            if (!skills[k].skillIsActive)
            {
                skillCheck();
            }

            /*for (int j = 0; j < skills.Count; j++)
            {
                if (skills[j].cooldown <= 0.0f && enemyState.enemyCanUseSkill)
                {
                    //if (skills[j].condition != Skill.Conditions.none) { //check la condition }
                    //else { skills[j].EnemyBehavior(); skills[j].cooldown = skills[j].cooldownValue; }

                    skills[j].skillIsActive = true;
                    skills[j].cooldown = skills[j].cooldownValue;
                }
            }*/
        }
    }

    void skillCheck()
    {
        if (generalCooldown <= 0.0f)
        {
            k = Random.Range(0, skills.Count);

            for (int u = 0; u < skills[k].conds.Count; u++)
            {
                if (enemyConditions.CheckCondition(skills[k].conds[u], skills[k].infos[u]) != true) { return; }
            }

            skills[k].skillIsActive = true;
            enemyState.enemyCanMove = false;

            generalCooldown = startGeneralCooldown;
        }

        else
        {
            generalCooldown -= Time.deltaTime;
        }
    }

    void TriggerCheck()
    {
        foreach (Trigger trig in triggers)
        {
            for (int o = 0; o < trig.conds.Count; o++)
            {
                if (enemyConditions.CheckCondition(triggers[k].conds[o], triggers[k].infos[o]) != true) { return; }
            }

            triggers[k].triggerIsActive = true;
            enemyState.enemyCanMove = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            behavior = Behaviors.combat;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            behavior = Behaviors.idle;
        }
    }
}
