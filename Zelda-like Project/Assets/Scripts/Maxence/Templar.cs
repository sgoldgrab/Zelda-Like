using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Templar : MonoBehaviour {

    //Checkpoint
    private Vector2 checkpoint;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    //Player position
    public Transform playerTransform;
    private Vector2 playerPosition;

    //Components
    private Animator templarAnimator;
    private BoxCollider2D templarCollider2D;
    private SpriteRenderer templarSpriteRenderer;

    private EnemySpawner enemySpawner;
    private PlayerAttack playerAttackScript;

    //Color change
    [SerializeField] private Color idleColor = Color.white;
    [SerializeField] private Color chaseColor;

    //Bools
    [HideInInspector] public bool templarIsHit = false;
    private bool templarIsDead = false;
    private bool templarIsAlive = true;
    private bool templarCanMove = true;
    private bool templarCanAttack;

    //templar caracteristics
    [SerializeField] private float templarSpeed;
    [SerializeField] private float templarHealth = 150;
    public float templarDamage;

    //Attack wait
    private float waitTilAttack = 4;
    [SerializeField] private float startWaitTilAttackMin;
    [SerializeField] private float startWaitTilAttackMax;

    //Movement wait
    private float waitTime = 0.0f;
    [SerializeField] private float startWaitTime;

    //Behaviors
    private enum TemplarBehaviors { patrol, chase };
    private TemplarBehaviors behavior = TemplarBehaviors.patrol;

    //Attack
    private Collider2D[] playerCollider;
    [SerializeField] private Transform templarAttackPos;
    [SerializeField] private float templarAttackRange;
    [SerializeField] private float templarAttackDistance;
    [SerializeField] private LayerMask thisIsThePlayer;

    void Start()
    {
        templarAnimator = GetComponent<Animator>(); // get the templar animator
        templarCollider2D = GetComponent<BoxCollider2D>(); // get the templar box collider 2D
        templarSpriteRenderer = GetComponent<SpriteRenderer>(); // get the templar sprite renderer

        templarAttackPos = GetComponentInChildren<Transform>();

        GameObject playerMessenger = GameObject.FindWithTag("Player"); // get the player transform and attack script

        if (playerMessenger != null)
        {
            playerTransform = playerMessenger.GetComponent<Transform>();
            playerAttackScript = playerMessenger.GetComponent<PlayerAttack>();
        }

        GameObject enemySpawnerMessenger = GameObject.FindWithTag("EnemySpawner"); // get the enemy spawner script

        if (enemySpawnerMessenger != null)
        {
            enemySpawner = enemySpawnerMessenger.GetComponent<EnemySpawner>();
        }

        waitTime = startWaitTime; // set the movement wait time
        checkpoint = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); // set the first checkpoint position
    }

    void Update()
    {
        if (behavior == TemplarBehaviors.patrol) // patrol behavior
        {
            IdleBehavior(); // moves from checkpoint to checkpoint
            templarSpriteRenderer.color = idleColor; // basic color indicator
        }

        if (behavior == TemplarBehaviors.chase) // chase behavior
        {
            ChaseBehavior(); // chase the player
            templarSpriteRenderer.color = chaseColor; // basic color indicator
            //Attack(); // basic sword attack
        }

        playerPosition = playerTransform.position;

        DamageToTheTemplar();
    }

    void ChaseBehavior() // follows the player and attacks him when reaching a certain distance
    {
        if (templarIsAlive)
        {
            if (templarCanMove)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, templarSpeed * Time.deltaTime);
            }

            if (Vector2.Distance(transform.position, playerTransform.position) <= templarAttackDistance)
            {
                templarCanMove = false;
                Attack();
            }

            if (Vector2.Distance(transform.position, playerTransform.position) > templarAttackDistance)
            {
                templarCanMove = true;
            }
        }
    }

    void Attack()
    {
        playerCollider = Physics2D.OverlapCircleAll(templarAttackPos.position, templarAttackRange, thisIsThePlayer);

        for (int u = 0; u < playerCollider.Length; u++)
        {
            if (playerCollider[u] is BoxCollider2D)
            {
                playerCollider[u].GetComponent<PlayerControllerEzEz>().playerIsHitByTheTemplar = true;
            }
        }

        if (templarAnimator.GetCurrentAnimatorStateInfo(0).IsName("templarIsHit") || !templarAnimator.GetCurrentAnimatorStateInfo(0).IsName("templarIsDead"))
        {
            templarAnimator.SetTrigger("templarAttacks");
        }
    }

    void IdleBehavior() // patrols around using random checkpoints
    {
        if (templarIsAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, checkpoint, templarSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, checkpoint) <= 0.2f)
            {
                if (waitTime <= 0)
                {
                    waitTime = startWaitTime;
                    float clsMinX = transform.position.x + minX;
                    float clsMaxX = transform.position.x + maxX;
                    float clsMinY = transform.position.y + minY;
                    float clsMaxY = transform.position.y + maxY;
                    checkpoint = new Vector2(Random.Range(clsMinX, clsMaxX), Random.Range(clsMinY, clsMaxY));
                }

                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    void DamageToTheTemplar()
    {
        if (templarIsHit)
        {
            templarHealth -= playerAttackScript.damage;
            templarIsHit = false;

            if (templarHealth <= 0)
            {
                templarAnimator.SetTrigger("templarIsDead"); // die animation
                templarCollider2D.enabled = false; // disable the enemy collider so you can walk past them
                templarIsAlive = false; // boolean that's used to disable the movement and firing functions of the enemy
                enemySpawner.enemiesAlive -= 1; // update the count of enemies alive
                StartCoroutine(WaitForDeath()); // templar destruction
            }

            else if (templarHealth > 0)
            {
                templarAnimator.SetTrigger("templarIsHit"); // hit animation
                Debug.Log("Damage to the Templaaaar !!!");
                Debug.Log(templarHealth);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            behavior = TemplarBehaviors.chase;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            behavior = TemplarBehaviors.patrol;
        }
    }

    IEnumerator WaitForDeath() // wait for seconds before destroying the templar game object
    {
        yield return new WaitForSecondsRealtime(1);

        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(templarAttackPos.position, templarAttackRange);
    }
}

