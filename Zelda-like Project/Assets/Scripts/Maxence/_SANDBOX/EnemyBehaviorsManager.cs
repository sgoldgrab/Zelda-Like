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
    FollowingAttack,
    None
}

public abstract class Behavior : MonoBehaviour
{
    public abstract void EnemyBehavior();

    [SerializeField] protected EnemyState enemyState;
    [SerializeField] protected EnemyAnims enemyAnims;

    [SerializeField] protected float enemyBaseSpeed;
    public float enemyGlobalSpeed { get => enemyBaseSpeed; set => enemyBaseSpeed = value; }
}

public abstract class Ability : Behavior
{
    [SerializeField] private List<Conditions> conditions;
    public List<Conditions> conds { get => conditions; protected set => conditions = value; }

    [SerializeField] private List<ConditionInfo> conditionInfos;
    public List<ConditionInfo> infos { get => conditionInfos; protected set => conditionInfos = value; }

    public string abilityName;
    
    [SerializeField] protected int animIndex;

    public bool skillIsActive { get; set; } = false;
    public abstract void AbilityAnimMethod();
}

public abstract class Skill : Ability
{
    public float additionalCooldown { get; protected set; } = 0.0f;
}

public abstract class Trigger : Skill
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

    private List<Skill> skillStock = new List<Skill>();
    [SerializeField] private int[] randomValue;

    private bool skillIsValid = true;
    private bool triggerIsValid = true;

    [SerializeField] private List<Trigger> triggers;
    public List<Trigger> theTriggers { get => triggers; private set => triggers = value; }

    [SerializeField] private Behavior moveIdleBehavior;
    [SerializeField] private Behavior moveCombatBehavior;
    public Behavior enemyMovement { get => moveCombatBehavior; set => moveCombatBehavior = value; }

    [SerializeField] private float startGeneralCooldown;
    public float generalCooldown { get; private set; } = 0.0f;
    public int k { get; private set; } = 0;

    //Test
    [SerializeField] private bool docile;

    void Start()
    {
        player = GameObject.Find(playerName);

        generalCooldown = startGeneralCooldown;

        for (int p = 0; p < skills.Count; p++)
        {
            for (int s = 0; s < randomValue[p]; s++)
            {
                skillStock.Add(skills[p]);
            }
        }
    }

    void FixedUpdate()
    {
        /*
        if (triggers[0].triggerIsActive) gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        else gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;

        Debug.Log(triggers[0].triggerIsActive);
        */

        if (enemyState.health <= 0) return;

        if (player.GetComponent<PlayerState>().health <= 0 || docile) behavior = Behaviors.idle;

        if (behavior == Behaviors.idle)
        {
            moveIdleBehavior.EnemyBehavior();
        }

        else if (behavior == Behaviors.combat)
        {
            if (enemyState.enemyCanMove) moveCombatBehavior.EnemyBehavior();

            if (skillStock.Count > 0)
            {
                if (!skillStock[k].skillIsActive) // check if a skill is currently active
                {
                    skillCheck();
                }
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
            k = Random.Range(0, skillStock.Count);

            for (int u = 0; u < skillStock[k].conds.Count; u++)
            {
                if (enemyConditions.CheckCondition(skillStock[k].conds[u], skillStock[k].infos[u]) == false) skillIsValid = false;
            }

            if (skillIsValid)
            {
                //activate the skill
                enemyState.enemyCanMove = false;
                skillStock[k].skillIsActive = true;

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
        for (int t = 0; t < triggers.Count; t++)
        {
            for (int o = 0; o < triggers[t].conds.Count; o++)
            {
                if (enemyConditions.CheckCondition(triggers[t].conds[o], triggers[t].infos[o]) == false) triggerIsValid = false;
            }

            if (triggerIsValid)
            {
                //activate the trigger
                triggers[t].triggerIsActive = true;
                if (skillStock.Count > 0) skillStock[k].skillIsActive = false; // cancel the current skill, if any
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
        if (other.gameObject.CompareTag("Detect"))
        {
            behavior = Behaviors.combat;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Detect"))
        {
            behavior = Behaviors.idle;
        }
    }
}
