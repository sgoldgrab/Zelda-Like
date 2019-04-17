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

    public float cooldownValue;
    public float cooldown { get; set; }

    void Update()
    {
        CoolDown();
    }

    void CoolDown()
    {
        cooldown -= Time.deltaTime;
    }
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

    void Start()
    {
        player = GameObject.Find(playerName);
    }

    void Update()
    {
        if (enemyState.health <= 0) { return; }

        if (behavior == Behaviors.idle)
        {
            moveIdleBehavior.EnemyBehavior();

            //IdleEvent.Invoke();

            //OnIdleAction();
        }

        else if (behavior == Behaviors.combat)
        {
            if (enemyState.enemyCanMove)
            {
                moveCombatBehavior.EnemyBehavior();

                //CombatEvent.Invoke();
            }

            for (int j = 0; j < skills.Count; j++)
            {
                if (skills[j].cooldown <= 0.0f && enemyState.enemyCanUseSkill)
                {
                    //if (skills[j].condition != Skill.Conditions.none) { //check la condition }
                    //else { skills[j].EnemyBehavior(); skills[j].cooldown = skills[j].cooldownValue; }

                    skills[j].skillIsActive = true;
                    skills[j].cooldown = skills[j].cooldownValue;
                }
            }

            //OnCombatAction();
        }
    }

    void ChoseBehavior()
    {
        /*if (Vector2.Distance(player.transform.position, transform.position) > range)
        {

        }

        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.Mouse0))
        {

        }

        if (transform.GetComponent<EntityUI>().BroadcastMessage("UITakeDamage", int param = 1))
        {

        }*/
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
