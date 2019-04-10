using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : EntityState
{
    [SerializeField] private EnemyAnims enemyAnims;
    //[SerializeField] private EnemyUI enemyUI;

    // HEALTH BAR INSTANTIATE
    [SerializeField] private GameObject[] enemyHealthSegs;
    [SerializeField] private float offsetValue = 0.4f;

    // ON DEATH REQUIRED
    [SerializeField] private Collider2D[] enemyCollider;
    [SerializeField] private EnemySpawner enemySpawner;

    public override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg); // loses health

        enemyAnims.DamageAnim(); // trigger the anim // the OnDeath() Method is activated through the playerAnims script, with the death animation.

        if (health <= 0)
        {
            foreach (Collider2D col in enemyCollider) { col.enabled = false; }
            enemySpawner.enemiesAlive -= 1;

            return;
        }

        //enemyUI.UITakeDamage(health, dmg);
    }

    public override void TakeHeal(int heal)
    {
        base.TakeHeal(heal);

        if (health >= maxHealth)
        {
            return;
        }

        //enemyUI.UITakeHealth(health, heal);
    }

    public void EnemyHealthBarDisplay()
    {
        int multiple = 1;
        float offsetX = 0.0f;
        int index = 0;

        foreach (GameObject prefab in enemyHealthSegs)
        {
            Instantiate(enemyHealthSegs[index], new Vector2(transform.position.x + offsetX, transform.position.y), Quaternion.identity);
            offsetX = 0.0f;
            index++;
            if (index % 2 == 1) //odd
            {
                offsetX += offsetValue * multiple;
                multiple++;
            }
            else if (index % 2 == 0) //even
            {
                offsetX -= offsetValue * multiple;
            }
        }
    }
}
