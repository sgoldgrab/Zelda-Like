using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : Enemy
{
    //IDLE
    private float idlePauseTime;
    [SerializeField] protected float idleStartPauseTime;
    public float idleWalkDistance; // useless

    [SerializeField] protected float minX;
    [SerializeField] protected float maxX;
    [SerializeField] protected float minY;
    [SerializeField] protected float maxY;

    protected Vector2 checkpoint;

    void Update()
    {
        if (currentBehavior == behavior.patrol)
        {
            IdleBehavior();
        }
    }

    void IdleBehavior()
    {
        if (isAlive)
        {
            if (Vector2.Distance(transform.position, checkpoint) <= 0.2f)
            {
                //animator.SetBool("templarIsMoving", false);

                if (idlePauseTime <= 0)
                {
                    idlePauseTime = idleStartPauseTime;
                    float currentMinX = transform.position.x + minX;
                    float currentMaxX = transform.position.x + maxX;
                    float currentMinY = transform.position.y + minY;
                    float currentMaxY = transform.position.y + maxY;
                    checkpoint = new Vector2(Random.Range(currentMinX, currentMaxX), Random.Range(currentMinY, currentMaxY));
                }

                else
                {
                    idlePauseTime -= Time.deltaTime;
                }
            }

            else if (canMove)
            {
                //animator.SetBool("templarIsMoving", true);
                transform.position = Vector2.MoveTowards(transform.position, checkpoint, speed * Time.deltaTime);
            }
        }
    }
}
