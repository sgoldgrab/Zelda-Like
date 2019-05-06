using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexMoveBehavior : Behavior
{
    private Vector2 checkpoint;

    public override void EnemyBehavior()
    {
        if (Vector2.Distance(transform.position, checkpoint) <= 0.0f)
        {
            Checkpoint();
        }

        else
        {
            enemyState.isMoving = true;

            transform.position = Vector2.MoveTowards(transform.position, checkpoint, enemyBaseSpeed * Time.deltaTime);
        }
    }

    void Checkpoint()
    {
        //Vector2 desiredPos = transform.position + ton oncl
    }
}
