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

    [SerializeField] protected float enemyBaseSpeed;
    public float enemyGlobalSpeed { get => enemyBaseSpeed; set => enemyBaseSpeed = value; }
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

    private bool skillIsValid = true;
    private bool triggerIsValid = true;

    [SerializeField] private List<Trigger> triggers;

    [SerializeField] private Behavior moveIdleBehavior;
    [SerializeField] private Behavior moveCombatBehavior;
    public Behavior enemyMovement { get => moveCombatBehavior; set => moveCombatBehavior = value; }

    [SerializeField] private float startGeneralCooldown;
    public float generalCooldown { get; private set; } = 0.0f;
    public int k { get; private set; } = 0;

    void Start()
    {
        player = GameObject.Find(playerName);
    }

    void FixedUpdate()
    {
        //Debug.Log(generalCooldown);

        if (enemyState.health <= 0) return;

        if (player.GetComponent<PlayerState>().health <= 0) behavior = Behaviors.idle;

        if (behavior == Behaviors.idle)
        {
            moveIdleBehavior.EnemyBehavior();
        }

        else if (behavior == Behaviors.combat)
        {
            if (enemyState.enemyCanMove) moveCombatBehavior.EnemyBehavior();

            if (!skills[k].skillIsActive) // check if a skill is currently active
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

            TriggerCheck();
        }
    }

    void skillCheck()
    {
        if (generalCooldown <= 0.0f)
        {
            k = Random.Range(0, skills.Count);

            for (int u = 0; u < skills[k].conds.Count; u++)
            {
                if (enemyConditions.CheckCondition(skills[k].conds[u], skills[k].infos[u]) == false) skillIsValid = false;
            }

            if (skillIsValid)
            {
                //activate the skill
                skills[k].skillIsActive = true;
                enemyState.enemyCanMove = false;

                generalCooldown = startGeneralCooldown;
            }

            else
            {
                // does nothing

                skillIsValid = true; // reset for another skill check
            }
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
                if (enemyConditions.CheckCondition(triggers[k].conds[o], triggers[k].infos[o]) == false) triggerIsValid = false;
            }

            if (triggerIsValid)
            {
                //activate the trigger
                triggers[k].triggerIsActive = true;
                enemyState.enemyCanMove = false;
            }

            else
            {
                // does nothing

                triggerIsValid = true; // reset for another trigger check
            }
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
