using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehavior : Behavior
{
    private Vector2 desiredPosition;
    [SerializeField] private float distance;
    [SerializeField] private float safeDistance;

    public float waitTime { get; private set; } = 0.0f;
    [SerializeField] private float startWaitTime;

    [SerializeField] private float fleeDuration;
    private float duration;

    private bool move;

    void Start()
    {
        duration = fleeDuration;
    }

    public override void EnemyBehavior()
    {
        if (enemyState.enemyCanMove && move)
        {
            Flee();
        }

        else if (waitTime <= 0)
        {
            waitTime = startWaitTime;

            if (Vector2.Distance(transform.position, enemyState.playerTransform.position) <= safeDistance)
            {
                calculateNewPosition();
                move = true;
                duration = fleeDuration;
            }
        }

        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    void Flee()
    {
        transform.position = Vector2.MoveTowards(transform.position, desiredPosition, enemyBaseSpeed * Time.deltaTime);

        if (duration <= 0.0f)
        {
            move = false;
        }

        else
        {
            duration -= Time.deltaTime;
        }
    }

    void calculateNewPosition()
    {
        Vector2 fleeDirection = transform.position - enemyState.playerTransform.position;
        desiredPosition = fleeDirection.normalized * distance;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, safeDistance);
    }
}
