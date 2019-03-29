using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New enemy stats", menuName = "Enemy stats initialization")]
public class EnemyStatsScriptableObject : ScriptableObject
{

    public int attackDamage;
    public float movementSpeed;
    public float rangeOfSight;
    public float attackRadius;
    public float waitBetweenAttacks;
    public float waitBetweenCombos;

}
