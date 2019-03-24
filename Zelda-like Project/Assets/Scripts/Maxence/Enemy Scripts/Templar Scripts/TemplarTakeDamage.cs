using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplarTakeDamage : MonoBehaviour
{
    //templar caracteristics
    [SerializeField] private float templarHealth = 150;

    //Components
    private Animator templarAnimator;
    private BoxCollider2D templarCollider2D;

    private EnemySpawner enemySpawner;
    private PlayerAttack playerAttackScript;

    //Bools
    [HideInInspector] public bool templarIsHit = false;
    private bool templarIsAlive = true;
    private bool templarCanMove = true;
    private bool templarCanAttack = true;

    //UI HEALTH\\
    private EnemyHealthBar templarHealthBarScript;

    void TakeDamage()
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
        }

        templarHealthBarScript.Damaged();
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
}
