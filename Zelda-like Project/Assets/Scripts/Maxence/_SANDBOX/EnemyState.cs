using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : EntityState
{
    //[SerializeField] private EnemyAnims enemyAnims;
    //[SerializeField] private EnemyUI enemyUI;

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
}
