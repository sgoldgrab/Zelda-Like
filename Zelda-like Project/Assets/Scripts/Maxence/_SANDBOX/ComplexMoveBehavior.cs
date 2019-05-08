using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexMoveBehavior : Behavior
{
    [SerializeField] private float pauseTime = 0.2f;
    private float time;

    [SerializeField] private float moveDurationMax;
    [SerializeField] private float moveDurationMin;
    private float moveTime;

    private Vector2 direction;

    private bool move;

    [SerializeField] private float maxDist;
    [SerializeField] private float minDist;

    public override void EnemyBehavior()
    {
        if (enemyState.enemyCanMove && move)
        {
            Movement();
        }

        else if (time <= 0)
        {
            time = pauseTime;

            NewDirection();
            move = true;
            enemyState.isMoving = true;

            moveTime = Random.Range(moveDurationMin, moveDurationMax);
        }

        else
        {
            time -= Time.deltaTime;
        }
    }

    void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, enemyBaseSpeed * Time.deltaTime);

        if (moveTime <= 0.0f)
        {
            move = false;
            enemyState.isMoving = false;
        }

        else
        {
            moveTime -= Time.deltaTime;
        }
    }

    void NewDirection()
    {
        int[] values = new int[2];
        values[0] = 1;
        values[1] = -1;

        Vector3 dir = new Vector2(values[Random.Range(0, 2)], values[Random.Range(0, 2)]);
        direction = transform.position + dir;

        if (Vector2.Distance(transform.position, enemyState.playerTransform.position) <= minDist) // too close
        {
            Vector3 backwards = transform.position - enemyState.playerTransform.position;
            direction = transform.position + backwards.normalized;
        }

        else if (Vector2.Distance(transform.position, enemyState.playerTransform.position) >= maxDist) // too far
        {
            Vector3 forward = enemyState.playerTransform.position - transform.position;
            direction = transform.position + forward.normalized;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minDist);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, maxDist);
    }
}
