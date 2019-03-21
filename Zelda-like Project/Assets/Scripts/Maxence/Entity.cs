using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void TakeDamage(float health, float damage, EnemyHealthBar healthBar)
    {
        health -= damage;

        //canMove = false; // put it just before the call of this method
        //canAttack = false; // put it just before the call of this method

        if (health <= 0)
        {
            // death behavior

            /*animator.SetTrigger("templarIsDead");
            collider2D.enabled = false;
            isAlive = false;
            enemySpawner.enemiesAlive -= 1;*/
        }

        else if (health > 0)
        {
            // hit behavior

            /*animator.SetTrigger("templarIsHit");*/
        }

        healthBar.Damaged();
    }

    void Recover(bool canMove, bool canAttack, bool isHit)
    {
        canMove = true;
        canAttack = true;

        isHit = false;
    }

    void Death(GameObject obj)
    {
        Destroy(obj);
    }
}
