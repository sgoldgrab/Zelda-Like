using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehavior : MovementBehavior
{
    [SerializeField] private float distance;
    [SerializeField] private float safeDistance;

    void Start()
    {
        duration = moveDuration;
    }

    public override void EnemyBehavior()
    {
        if (Vector2.Distance(transform.position, enemyState.playerTransform.position) >= safeDistance) otherCondition = false;
        else otherCondition = true;

        base.EnemyBehavior();
    }

    public override void NewDirection()
    {
        Vector2 fleeDirection = transform.position - enemyState.playerTransform.position;
        direction = fleeDirection.normalized * distance;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, safeDistance);
    }
}
