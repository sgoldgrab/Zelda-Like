using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyBehavior : MonoBehaviour {

    private PlayerAttack playerAttack;

    private Transform playerTransform;
    [HideInInspector] public Vector2 playerPos;

    private Animator enemyAnimator;
    private BoxCollider2D enemyCollider2D;
    private SpriteRenderer enemySpriteR;
    private EnemySpawner enemySpawner;

    [HideInInspector] public bool enemyWasHit = false;
    [HideInInspector] public bool enemyHasFallen = false;

    [HideInInspector] public bool isAlive = true;

    public GameObject fireBall;

    private float waitTilAttack = 4;
    [SerializeField]
    private float startWaitTilAttackMin;
    [SerializeField]
    private float startWaitTilAttackMax;

    private float waitRate = 0;
    [SerializeField]
    private float startWaitRate;

    [HideInInspector] public bool canMove = true;
    [HideInInspector] public bool canAttack; //\

    private float rate;
    [SerializeField]
    private float startRate;

    [HideInInspector] public enum Behavior { patrol, flee };
    [HideInInspector] public Behavior whatBehavior = Behavior.patrol;

    [SerializeField]
    private Color fleeColor;
    [SerializeField]
    private Color patrolColor = Color.white;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyCollider2D = GetComponent<BoxCollider2D>();
        enemySpriteR = GetComponent<SpriteRenderer>();

        GameObject enemySpawnerMessenger = GameObject.FindWithTag("EnemySpawner");

        if (enemySpawnerMessenger != null)
        {
            enemySpawner = enemySpawnerMessenger.GetComponent<EnemySpawner>();
        }

        GameObject playerMessenger = GameObject.FindWithTag("Player");

        if (playerMessenger != null)
        {
            playerTransform = playerMessenger.GetComponent<Transform>();
        }

        rate = startRate;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            playerPos = playerTransform.position;
        }
        
        DamageToTheEnemy();

        if (whatBehavior == Behavior.flee)
        {
            enemySpriteR.color = fleeColor;
            RangedAttack();
        }

        else if (whatBehavior == Behavior.patrol)
        {
            enemySpriteR.color = patrolColor;
        }
    }

    void RangedAttack()
    {
        if (isAlive)
        {
            if (waitTilAttack <= 0.8 && waitTilAttack > 0.7)
            {
                enemyAnimator.SetTrigger("enemyAttack");
            }

            if (waitTilAttack <= 0.1)
            {
                canMove = false;

                if (rate > 0)
                {
                    if (waitRate <= 0.1)
                    {
                        GameObject bullet = Instantiate(fireBall, transform.position, transform.rotation);
                        bullet.GetComponent<FireBallMove>().SetPlayerPos(playerPos);
                        waitRate = startWaitRate;
                        rate -= 1;
                    }

                    else
                    {
                        waitRate -= Time.deltaTime;
                    }
                }

                else
                {
                    waitTilAttack = Random.Range(startWaitTilAttackMin, startWaitTilAttackMax);
                    rate = startRate;
                }
            }

            else
            {
                canMove = true;

                waitTilAttack -= Time.deltaTime;
            }
        }
    }

    void DamageToTheEnemy()
    {
        if (enemyWasHit)
        {
            enemyWasHit = false;
            enemyAnimator.SetTrigger("enemyIsHit"); // hit animation
        }

        if (enemyHasFallen)
        {
            enemyHasFallen = false;
            enemyAnimator.SetTrigger("enemyIsDead"); // die animation
            enemyCollider2D.enabled = false; // disable the enemy collider so you can walk past them
            isAlive = false; // boolean that's used to disable the movement and firing functions of the enemy
            enemySpawner.enemiesAlive -= 1;
            StartCoroutine(WaitingForDeath()); // wait for seconds before destroying the object
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            whatBehavior = Behavior.flee;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            whatBehavior = Behavior.patrol;
            //Debug.Log(other.gameObject.name + " might be the son of bitch");
        }
    }

    IEnumerator WaitingForDeath() // wait for seconds before destroying the fireball
    {
        yield return new WaitForSecondsRealtime(1);

        Destroy(gameObject); // destroy the fireball
    }

    //gameObject.transform
}