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
    private bool templarIsDead = false; // useless \\
    private bool templarIsAlive = true;
    private bool templarCanMove = true;
    private bool templarCanAttack = true;
    private bool flipTemplar = false; // useless \\

    //templar caracteristics
    public float templarSpeed;
    [SerializeField] private float templarHealth = 150;
    public float templarDamage;

    //Attack wait // USELESS VARIABLES \\
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
    [SerializeField] private float templarAttackZoneRadius;
    [SerializeField] private float templarAttackDistance; // equivalent to attack Range
    [SerializeField] private LayerMask thisIsThePlayer;

    private float attackWaitTime = 0.0f;
    [SerializeField] private float startAttackWaitTime;

    private float attackWaitRate = 0.0f;
    [SerializeField] private float startAttackWaitRate;
    private int rate = 2;
    [SerializeField] private int startRate;

    //UI HEALTH\\
    public GameObject templarHealthBarPrefab;
    private GameObject templarHealthBar;
    private EnemyHealthBar templarHealthBarScript;
    [SerializeField] private float offsetUI;

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

        //UI TESTING\\
        templarHealthBar = Instantiate(templarHealthBarPrefab, new Vector2(transform.position.x, transform.position.y + offsetUI), Quaternion.identity);
        templarHealthBar.transform.parent = transform;

        templarHealthBarScript = templarHealthBar.GetComponent<EnemyHealthBar>();
    }

    void Update()
    {
        FlipTemplar();

        if (behavior == TemplarBehaviors.patrol) // patrol behavior
        {
            IdleBehavior(); // moves from checkpoint to checkpoint
            templarSpriteRenderer.color = idleColor; // basic color indicator
        }

        if (playerTransform == null) return;

        if (behavior == TemplarBehaviors.chase) // chase behavior
        {
            ChaseBehavior(); // chase the player
            templarSpriteRenderer.color = chaseColor; // basic color indicator
        }

        DamageToTheTemplar();
    }

    void ChaseBehavior() // follows the player and attacks him when reaching a certain distance
    {
        if (templarIsAlive)
        {
            if (Vector2.Distance(transform.position, playerTransform.position) > templarAttackDistance && templarCanMove)
            {
                templarAnimator.SetBool("templarIsMoving", true);
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, templarSpeed * Time.deltaTime);
            }

            else if (Vector2.Distance(transform.position, playerTransform.position) <= templarAttackDistance)
            {
                templarAnimator.SetBool("templarIsMoving", false);
                LaunchAttack();
            }

            else
            {
                templarAnimator.SetBool("templarIsMoving", false);
            }
        }

        else
        {
            templarAnimator.SetBool("templarIsMoving", false);
        }
    }

    void LaunchAttack()
    {
        if (templarCanAttack)
        {
            if(attackWaitTime <= 0.1f)
            {
                if(rate > 0)
                {
                    if(attackWaitRate <= 0.1f)
                    {
                        templarAnimator.SetTrigger("templarAttacks");
                        attackWaitRate = startAttackWaitRate;
                        rate--;
                    }

                    else
                    {
                        attackWaitRate -= Time.deltaTime;
                    }
                }

                else
                {
                    attackWaitTime = startAttackWaitTime;
                    rate = startRate;
                }
            }

            else
            {
                attackWaitTime -= Time.deltaTime;
            }
        }
    }

    void Attack()
    {
        playerCollider = Physics2D.OverlapCircleAll(templarAttackPos.position, templarAttackZoneRadius, thisIsThePlayer);

        for (int u = 0; u < playerCollider.Length; u++)
        {
            if (playerCollider[u] is BoxCollider2D)
            {
                playerCollider[u].GetComponent<PlayerControllerEzEz>().DamageToThePlayer(this);
            }
        }

        /*if (!templarAnimator.GetCurrentAnimatorStateInfo(0).IsName("templarIsHit") || !templarAnimator.GetCurrentAnimatorStateInfo(0).IsName("templarIsDead"))
        {
            templarAnimator.SetTrigger("templarAttacks");
        }*/
    }

    void IdleBehavior() // patrols around using random checkpoints
    {
        if (templarIsAlive)
        {
            if (Vector2.Distance(transform.position, checkpoint) <= 0.2f)
            {
                templarAnimator.SetBool("templarIsMoving", false);

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

            else if (templarCanMove)
            {
                templarAnimator.SetBool("templarIsMoving", true);
                transform.position = Vector2.MoveTowards(transform.position, checkpoint, templarSpeed * Time.deltaTime);
            }
        }
    }

    void DamageToTheTemplar()
    {
        if (templarIsHit)
        {
            templarHealth -= playerAttackScript.damage; // damage

            templarCanMove = false;
            templarCanAttack = false;

            templarIsHit = false;
            
            if (templarHealth <= 0)
            {
                templarAnimator.SetTrigger("templarIsDead");
                templarCollider2D.enabled = false; // disable the enemy collider so you can walk past them
                templarIsAlive = false; // boolean that's used to disable the behaviors of the enemy
                enemySpawner.enemiesAlive -= 1; // update the count of enemies alive
            }

            else if (templarHealth > 0)
            {
                templarAnimator.SetTrigger("templarIsHit");
                Debug.Log("Damage to the Templaaaar !!!");
                Debug.Log(templarHealth);

                /*if (!flipTemplar)
                {
                    templarAnimator.SetTrigger("templarIsHit");
                    Debug.Log("Damage to the Templaaaar !!!");
                    Debug.Log(templarHealth);
                }
                
                else if (flipTemplar)
                {
                    // other animation
                }*/
            }

            templarHealthBarScript.Damaged();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }

    void TemplarRecover()
    {
        templarCanMove = true;
        templarCanAttack = true;
    }

    void FlipTemplar()
    {
        if (transform.position.x >= playerTransform.position.x && transform.position.y < playerTransform.position.y) //faceUpLeft
        {
            templarAnimator.SetFloat("lastX", -1f);
            templarAnimator.SetFloat("lastY", 1f);
        }

        else if (transform.position.x < playerTransform.position.x && transform.position.y < playerTransform.position.y) //faceUpRight
        {
            templarAnimator.SetFloat("lastX", 1f);
            templarAnimator.SetFloat("lastY", 1f);
        }

        else if (transform.position.x >= playerTransform.position.x && transform.position.y >= playerTransform.position.y) //faceDownLeft
        {
            templarAnimator.SetFloat("lastX", -1f);
            templarAnimator.SetFloat("lastY", -1f);
        }

        else if(transform.position.x < playerTransform.position.x && transform.position.y >= playerTransform.position.y) //faceDownRight
        {
            templarAnimator.SetFloat("lastX", 1f);
            templarAnimator.SetFloat("lastY", -1f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            behavior = TemplarBehaviors.chase;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            behavior = TemplarBehaviors.patrol;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(templarAttackPos.position, templarAttackZoneRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, templarAttackDistance);
    }

    /*IEnumerator WaitForDeath()
    {
        yield return new WaitForSecondsRealtime(1);

        Destroy(gameObject);
    }*/
}

