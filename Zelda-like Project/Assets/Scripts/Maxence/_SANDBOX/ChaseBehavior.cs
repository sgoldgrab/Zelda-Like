using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehavior : Behavior
{
    [SerializeField] private EnemyAnims enemyAnims;
    [SerializeField] private EnemyState enemyState;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float minDist;
    [SerializeField] private float chaseSpeed;

    void Start()
    {
        EnemyBehaviorsManager.OnCombatAction += EnemyBehavior;
        EntityState.OnDeathAction += OnDeath;
    }

    public override void EnemyBehavior()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) > minDist && enemyState.enemyCanMove)
        {
            enemyAnims.MoveAnim(true);
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, chaseSpeed * Time.deltaTime);
        }

        else
        {
            enemyAnims.MoveAnim(false);
        }
    }

    void OnDeath()
    {
        EnemyBehaviorsManager.OnCombatAction -= EnemyBehavior;
        EntityState.OnDeathAction -= OnDeath;
    }
}
