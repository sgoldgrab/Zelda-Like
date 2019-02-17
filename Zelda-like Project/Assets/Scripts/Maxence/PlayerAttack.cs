using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

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
    
    public float damage = 25;

    private bool isDead;

    private PlayerControllerEzEz playerController;
    private Animator playerAnimator;

    private float waitForAttack = 0.0f;
    [SerializeField]
    private float startWaitForAttack;

    private EnemySpawner enemySpawnerBis;

    void Start()
    {
        playerController = GetComponent<PlayerControllerEzEz>();
        playerAnimator = GetComponent<Animator>();

        GameObject enemySpawnerMessenger = GameObject.FindWithTag("EnemySpawner");

        if (enemySpawnerMessenger != null)
        {
            enemySpawnerBis = enemySpawnerMessenger.GetComponent<EnemySpawner>();
        }
    }

	void Update ()
    {
        if (waitForAttack <= 0.1f)
        {
            if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.Mouse0)) // initialize an attack
            {
                //WhichSideToAttack();

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
        if (enemySpawnerBis.templarIsHere)
        {
            TestAttack();
        }

        if (!enemySpawnerBis.templarIsHere)
        {
            Attack();
        }
    }

    void Attack() // takes all enemies in the area of effect and deals damage to them
    {
        enemiesToDamage = Physics2D.OverlapCircleAll(attackPositions[8].position, attackRange, thisIsAnEnemy); // creates the area and takes the enemy collider(s) inside

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            if(enemiesToDamage[i] is BoxCollider2D)
            {
                enemiesToDamage[i].GetComponent<EnemyCaracteristics>().enemyHealth -= damage; // access the enemy's Health script --> takes damage

                if (enemiesToDamage[i].GetComponent<EnemyCaracteristics>().enemyHealth <= 0) // ENEMY IS DEAD
                {
                    enemiesToDamage[i].GetComponent<RandomEnemyBehavior>().enemyHasFallen = true;
                }

                else if (enemiesToDamage[i].GetComponent<EnemyCaracteristics>().enemyHealth > 0) // ENEMY TAKES DAMAGE
                {
                    enemiesToDamage[i].GetComponent<RandomEnemyBehavior>().enemyWasHit = true;
                }

                Debug.Log("Daamaaage !!!");
                Debug.Log(enemiesToDamage[i].GetComponent<EnemyCaracteristics>().enemyHealth);
            }
        }
    }

    void TestAttack() // takes all enemies in the area of effect and deals damage to them
    {
        templarsToDamage = Physics2D.OverlapCircleAll(attackPositions[8].position, attackRange, thisIsAnEnemy); // creates the area and takes the enemy collider(s) inside

        for (int i = 0; i < templarsToDamage.Length; i++)
        {
            if (templarsToDamage[i] is BoxCollider2D)
            {
                templarsToDamage[i].GetComponent<Templar>().templarIsHit = true;
            }
        }
    }

    private int WhichSideToAttack()
    {
        if (playerController.horizontal == 0 && playerController.vertical == 0)
        {
            pos = 0;
            attackPosSprites[pos].enabled = true;
        }

        else if (playerController.horizontal == 0 && playerController.vertical == -1)
        {
            pos = 0;
            attackPosSprites[pos].enabled = true;
        }

        else if (playerController.horizontal == 0 && playerController.vertical == 1)
        {
            pos = 1;
            attackPosSprites[pos].enabled = true;
        }

        else if (playerController.horizontal == 1 && playerController.vertical == 0)
        {
            pos = 2;
            attackPosSprites[pos].enabled = true;
        }

        else if (playerController.horizontal == -1 && playerController.vertical == 0)
        {
            pos = 3;
            attackPosSprites[pos].enabled = true;
        }

        else if (playerController.horizontal == 1 && playerController.vertical == 1)
        {
            pos = 4;
            attackPosSprites[pos].enabled = true;
        }

        else if (playerController.horizontal == 1 && playerController.vertical == -1)
        {
            pos = 5;
            attackPosSprites[pos].enabled = true;
        }

        else if (playerController.horizontal == -1 && playerController.vertical == -1)
        {
            pos = 6;
            attackPosSprites[pos].enabled = true;
        }

        else if (playerController.horizontal == -1 && playerController.vertical == 1)
        {
            pos = 7;
            attackPosSprites[pos].enabled = true;
        }

        return pos;
    }

    void OnDrawGizmosSelected() // draws the area of effect of the attack in the editor, used for visualisation
    {
        for(int i = 0; i < attackPositions.Length; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(attackPositions[i].position, attackRange);
        }
    }
}