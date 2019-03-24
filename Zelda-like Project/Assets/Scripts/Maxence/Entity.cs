using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //GENERAL
    [SerializeField] protected float health;
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float resistance;

    [SerializeField] protected float damage;
    [SerializeField] protected float initDamage;

    [SerializeField] protected float speed;
    [SerializeField] protected float initSpeed;

    //COMPLEX DAMAGE
    [SerializeField] protected int damageIndex;
    [SerializeField] protected int bonusDamage;
    [SerializeField] protected int damageRateCoolDown;

    //BOOLS
    protected bool isAlive = true;
    protected bool canMove = true;
    protected bool canAttack = true;
    protected bool isHit; // possibly useless /!\

    //COMPONENTS
    protected Collider2D theCollider;

    public virtual void TakeDamage(float dmg, EnemyHealthBar healthBar) 
    {
        // remove the health bar parameter, replace it in both enemy and player scripts overrides of this function, 
        // as they are uncommun to one another

        health -= dmg;

        if (health <= 0)
        {
            theCollider.enabled = false;
            isAlive = false;

            // death behavior ()

            /*animator.SetTrigger("templarIsDead");*/
        }

        else if (health > 0)
        {
            // hit behavior ()

            /*animator.SetTrigger("templarIsHit");*/
        }

        healthBar.Damaged();
    }

    public virtual void TakeHealth(float heal, EnemyHealthBar healthBar)
    {
        health += heal;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthBar.Healed();
    }

    void Death(GameObject obj)
    {
        Destroy(obj); // see if the player stays when he dies, test with the menus, i dunno
    }
}
