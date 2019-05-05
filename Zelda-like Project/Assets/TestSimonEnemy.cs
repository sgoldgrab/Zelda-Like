using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSimonEnemy : EntityState
{
    [SerializeField] private bool isImmune = false;

    public delegate void EnemyHit();
    public static event EnemyHit whenEnemyHit;

    public delegate void EnemyKilled();
    public static event EnemyKilled whenEnemyDies;

    public override void TakeDamage(int dmg)
    {
        if(!isImmune)
        {
            base.TakeDamage(dmg);
            if (whenEnemyHit != null) { whenEnemyHit(); }
            Debug.Log("Health : " + health + " / " + maxHealth);
        }

        if(health <=0)
        {
            if(whenEnemyDies != null) { whenEnemyDies(); }
        }
    }

}
