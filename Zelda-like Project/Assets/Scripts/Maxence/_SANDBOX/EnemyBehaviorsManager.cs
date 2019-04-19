using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Behavior : MonoBehaviour
{
    public abstract void EnemyBehavior();
}

public abstract class Skill : Behavior
{
    [SerializeField] protected EnemyState enemyState;

    public bool skillIsActive { get; set; } = false;
    public float additionalCooldown { get; set; } = 0.0f;

    public enum Conditions { none, checkRange, checkEnemies }
    public Conditions condition { get; protected set; }
}

public class EnemyBehaviorsManager : MonoBehaviour
{
    //OLD DELEGATES --> to delete
    public delegate void IdleAction();
    public static event IdleAction OnIdleAction;

    public delegate void CombatAction();
    public static event CombatAction OnCombatAction;

    //OLD EVENTS --> to update
    public UnityEvent IdleEvent;
    public UnityEvent CombatEvent;

    //ENUMS
    public enum Behaviors { idle, combat }
    public Behaviors behavior { get; private set; } = Behaviors.idle;

    //COMPONENTS
    private GameObject player;
    [SerializeField] private string playerName;

    [SerializeField] private EnemyState enemyState;

    [SerializeField] private List<Skill> skills;

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
        Debug.Log(generalCooldown);

        if (enemyState.health <= 0) { return; }

        if (behavior == Behaviors.idle)
        {
            moveIdleBehavior.EnemyBehavior();
        }

        else if (behavior == Behaviors.combat)
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

            if (skills[k].condition != Skill.Conditions.none)
            {
                // check la condition
            }

            else
            {
                skills[k].skillIsActive = true;
                enemyState.enemyCanMove = false;

                generalCooldown = startGeneralCooldown;
            }
        }

        else
        {
            generalCooldown -= Time.deltaTime;
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
