using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlankingCircleBehavior : MovementBehavior
{
    private float angle;

    [SerializeField] private float reachDistance;

    void Start()
    {
        direction = transform.position + Vector3.right;
        //GenerateNewDirectrion();
        duration = moveDuration;
    }

    public override void EnemyBehavior()
    {
        base.EnemyBehavior();
    }

    public override void NewDirection()
    {
        angle += -45;
        Vector3 trigo = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        direction = transform.position + trigo;

        if (Vector2.Distance(transform.position, enemyState.playerTransform.position) >= reachDistance)
        {
            Vector2 drift = enemyState.playerTransform.position - transform.position;
            direction += drift;
        }

        Debug.DrawRay(transform.position, direction, Color.cyan, duration);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, reachDistance);
    }
}
