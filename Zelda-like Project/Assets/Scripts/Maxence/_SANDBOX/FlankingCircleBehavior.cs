using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlankingCircleBehavior : Behavior
{
    private Vector3 axis;

    [SerializeField] private float moveDuration;
    private float duration;

    private float angle;

    [SerializeField] private float reachDistance;

    void Start()
    {
        axis = transform.position + Vector3.right;
        //GenerateNewDirectrion();
        duration = moveDuration;
    }

    public override void EnemyBehavior()
    {
        transform.position = Vector2.MoveTowards(transform.position, axis, enemyBaseSpeed * Time.deltaTime);

        if (duration <= 0.0f)
        {
            GenerateNewDirectrion();

            enemyState.isMoving = true;
        }

        else
        {
            duration -= Time.deltaTime;
        }
    }

    void GenerateNewDirectrion()
    {
        duration = moveDuration;

        angle += -45;
        Vector3 trigo = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        axis = transform.position + trigo;

        if (Vector2.Distance(transform.position, enemyState.playerTransform.position) >= reachDistance)
        {
            Vector3 drift = enemyState.playerTransform.position - transform.position;
            axis += drift;
        }

        Debug.DrawRay(transform.position, axis, Color.cyan, duration);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, reachDistance);
    }
}
