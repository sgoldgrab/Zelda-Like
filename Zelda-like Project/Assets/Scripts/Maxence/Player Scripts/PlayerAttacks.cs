using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public int pos;
    private Collider2D[] enemiesToDamage;
    private Collider2D[] templarsToDamage;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private LayerMask thisIsAnEnemy;
    [SerializeField]
    private Transform[] attackPositions;
    [SerializeField]
    private SpriteRenderer[] attackPosSprites;

    [SerializeField]
    private float attackDistance;
    private Vector2 attackPos;
    private Vector2 transformPos;
    
    public float damage = 25;

    private bool isDead;

    private PlayerControllerEzEz playerController;
    private Animator playerAnimator;

    private float waitForAttack = 0.0f;
    [SerializeField]
    private float startWaitForAttack;

    private EnemySpawner enemySpawnerScript;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();

        GameObject playerControllerMessenger = GameObject.FindWithTag("Player");

        if (playerControllerMessenger != null)
        {
            playerController = playerControllerMessenger.GetComponent<PlayerControllerEzEz>();
        }

        GameObject enemySpawnerMessenger = GameObject.FindWithTag("EnemySpawner");

        if (enemySpawnerMessenger != null)
        {
            enemySpawnerScript = enemySpawnerMessenger.GetComponent<EnemySpawner>();
        }
    }

	void Update ()
    {
        transformPos = transform.position;

        AttackDirection();

        LaunchAttack();
	}

    void LaunchAttack()
    {
        if (waitForAttack <= 0.1f)
        {
            if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.Mouse0)) // initialize an attack
            {
                ChoseAttack();

                playerAnimator.SetTrigger("playerAttacks");

                for (int n = 0; n < attackPosSprites.Length; n++)
                {
                    attackPosSprites[n].enabled = false;
                }

                waitForAttack = startWaitForAttack;
            }
        }

        else
        {
            waitForAttack -= Time.deltaTime;
        }
    }

    void ChoseAttack() // USED FOR TESTING ONLY
    {
        if (enemySpawnerScript.templarIsHere)
        {
            TestAttack();
        }

        if (!enemySpawnerScript.templarIsHere)
        {
            Attack();
        }
    }

    void Attack() // takes all enemies in the area of effect and deals damage to them
    {
        enemiesToDamage = Physics2D.OverlapCircleAll(attackPositions[0].position, attackRange, thisIsAnEnemy); // creates the area and takes the enemy collider(s) inside

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            if(enemiesToDamage[i] is BoxCollider2D)
            {
                enemiesToDamage[i].GetComponent<RandomEnemyBehavior>().enemyWasHit = true;
            }
        }
    }

    void TestAttack() // takes all enemies in the area of effect and deals damage to them
    {
        templarsToDamage = Physics2D.OverlapCircleAll(attackPos, attackRange, thisIsAnEnemy); // creates the area and takes the enemy collider(s) inside

        for (int i = 0; i < templarsToDamage.Length; i++)
        {
            if (templarsToDamage[i] is BoxCollider2D)
            {
                templarsToDamage[i].GetComponent<Templar>().templarIsHit = true;
            }
        }
    }

    void AttackDirection()
    {
        if (playerController.lastX != 0 || playerController.lastY != 0)
        {
            float attackPosX = playerController.lastX;
            float attackPosY = playerController.lastY;

            Vector2 rawAttackCoordinates = new Vector2(attackPosX, attackPosY);
            Vector2 rawAttackPos = rawAttackCoordinates * attackDistance;
            attackPos = transformPos + rawAttackPos;
        }
    }

    void OnDrawGizmosSelected() // draws the area of effect of the attack in the editor, used for visualisation
    {
        //TEST ATTACK POSITIONING
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos, attackRange);

        //CURRENT ATTACK POSITION
        for(int i = 0; i < attackPositions.Length; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(attackPositions[i].position, attackRange);
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    /*enemiesToDamage[i].GetComponent<EnemyCaracteristics>().enemyHealth -= damage; // access the enemy's Health script --> takes damage

                if (enemiesToDamage[i].GetComponent<EnemyCaracteristics>().enemyHealth <= 0) // ENEMY IS DEAD
                {
                    enemiesToDamage[i].GetComponent<RandomEnemyBehavior>().enemyHasFallen = true;
                }

                else if (enemiesToDamage[i].GetComponent<EnemyCaracteristics>().enemyHealth > 0) // ENEMY TAKES DAMAGE
                {
                    enemiesToDamage[i].GetComponent<RandomEnemyBehavior>().enemyWasHit = true;
                }

                Debug.Log("Daamaaage !!!");
                Debug.Log(enemiesToDamage[i].GetComponent<EnemyCaracteristics>().enemyHealth);*/
}