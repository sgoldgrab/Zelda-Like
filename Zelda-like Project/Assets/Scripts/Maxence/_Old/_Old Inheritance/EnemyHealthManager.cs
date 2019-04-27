using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : HealthManager
{
    private EnemySpawner enemySpawner;

    void Start()
    {
        GameObject enemySpawnerMessenger = GameObject.FindWithTag("EnemySpawner"); // get the enemy spawner script

        if (enemySpawnerMessenger != null)
        {
            enemySpawner = enemySpawnerMessenger.GetComponent<EnemySpawner>();
        }
    }

    public override void TakeDamage(float dmg, EnemyHealthBar healthBar)
    {
        canAttack = false;
        canMove = false;

        base.TakeDamage(dmg, healthBar);

        // death behavior () --> specific to a certain enemy/entity, override the take damage in a new script, "death behavior" for instance.

        if (health <= 0)
        {
            enemySpawner.enemiesAlive -= 1;

            // hit behavior () --> or make a script "hit behavior", with no inheritance, that will just check if the enemy is hit or not, to activate.
        }
    }

    void Recover()
    {
        canMove = true;
        canAttack = true;

        isHit = false; // possibly useless /!\
    }
}
