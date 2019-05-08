using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Health
{
    public int currentHealth;
    public int maxHealth;

    public void TakeDamage(int damageValue)
    {
        currentHealth = Mathf.Clamp(currentHealth - damageValue, 0, maxHealth);
    }

    public void TakeHeal(int healValue)
    {
        currentHealth = Mathf.Clamp(currentHealth + healValue, 0, maxHealth);
    }

    /*public Health(HealthScriptableObject healthSCO)
    {

        maxHealth = healthSCO.maxHealth;
        currentHealth = healthSCO.currentHealth;

    }*/

}

[System.Serializable]
public class PlayerStats
{
    public int attackDamage;
    public float attackSpeed;
    public float movementSpeed;
    public int rangeOfSight;
    public float cooldownReduction;
}

[System.Serializable]
public class EnemyStats
{
    public int attackDamage;
    public float movementSpeed;
    public float rangeOfSight;
    public float attackRadius;
    public float waitBetweenAttacks;
    public float waitBetweenCombos;

    /*public EnemyStats(EnemyStatsScriptableObject enemyStatsSCO)
    {

        attackDamage = enemyStatsSCO.attackDamage;
        movementSpeed = enemyStatsSCO.movementSpeed;
        rangeOfSight = enemyStatsSCO.rangeOfSight;
        waitBetweenAttacks = enemyStatsSCO.waitBetweenAttacks;
        waitBetweenCombos = enemyStatsSCO.waitBetweenCombos;

    }*/
}