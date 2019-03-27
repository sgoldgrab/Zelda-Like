using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : Entity
{
    [SerializeField] private Animator animator;
    [SerializeField] private string animDeathTriggerText;
    [SerializeField] private string animHitTriggerText;

    public virtual void TakeDamage(float dmg, EnemyHealthBar healthBar)
    {
        health -= dmg;

        if (health <= 0)
        {
            animator.SetTrigger(animDeathTriggerText);
            theCollider.enabled = false;
            isAlive = false;
        }

        else if (health > 0)
        {
            animator.SetTrigger(animHitTriggerText);
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
