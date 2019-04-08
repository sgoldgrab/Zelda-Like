using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : EntityState
{
    //[SerializeField] private EnemyAnims enemyAnims;
    //[SerializeField] private EnemyUI enemyUI;

    [SerializeField] private GameObject[] enemyHealthSegs;

    [SerializeField] private float offsetValue = 0.4f;

    public override void TakeDamage(int dmg)
    {
        //enemyAnims.DamageAnim(); // the OnDeath() Method is activated through the playerAnims script, with the death animation.

        if (health <= 0) { return; }

        //enemyUI.UITakeDamage(health, dmg);

        base.TakeDamage(dmg);
    }

    public override void TakeHeal(int heal)
    {
        base.TakeHeal(heal);

        if (health >= maxHealth) { return; }

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
