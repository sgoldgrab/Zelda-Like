using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //GENERAL
    public float health;
    public float maxHealth;
    public float resistance;

    public float damage;
    public float initDamage;

    public float speed;
    public float initSpeed;

    //COMPLEX DAMAGE
    public int damageIndex;
    public int bonusDamage;
    public int damageRateCoolDown;

    void TakeDamage(float dmg, EnemyHealthBar healthBar)
    {
        health -= dmg;

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

    void TakeHealth(float heal, EnemyHealthBar healthBar)
    {
        health += heal;

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        healthBar.Healed();
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
