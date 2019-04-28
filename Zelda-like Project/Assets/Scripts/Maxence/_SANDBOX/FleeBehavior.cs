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

    void Start()
    {
        desiredPosition = transform.position;
    }

    public override void EnemyBehavior()
    {
        transform.position = Vector2.MoveTowards(transform.position, desiredPosition, enemyBaseSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, desiredPosition) <= 0.0f)
        {
            if (waitTime <= 0)
            {
                waitTime = startWaitTime;

                if (Vector2.Distance(transform.position, enemyState.playerTransform.position) <= safeDistance)
                {
                    calculateNewPosition();
                }
            }

            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void calculateNewPosition()
    {
        Vector2 fleeDirection = transform.position - enemyState.playerTransform.position;
        desiredPosition = fleeDirection.normalized * distance;
    }
}
