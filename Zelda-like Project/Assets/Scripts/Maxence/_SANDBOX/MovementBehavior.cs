using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : Behavior
{
    protected bool moves;

    protected bool otherCondition = true;

    [SerializeField] protected float moveDuration;
    protected float duration;

    [SerializeField] protected float pauseTime;
    protected float pause;

    protected Vector2 direction;

    public override void EnemyBehavior()
    {
        if (enemyState.enemyCanMove && moves)
        {
            Movement();
        }

        else if (pause <= 0.0f && otherCondition)
        {
            pause = pauseTime;

            NewDirection();
            moves = true;
            enemyState.isMoving = true;

            duration = moveDuration;
        }

        else
        {
            pause -= Time.deltaTime;
        }
    }

    public virtual void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, enemyBaseSpeed * Time.deltaTime);

        if (duration <= 0.0f)
        {
            moves = false;
            enemyState.isMoving = false;
        }

        else
        {
            duration -= Time.deltaTime;
        }
    }

    public virtual void NewDirection()
    {

    }
}
