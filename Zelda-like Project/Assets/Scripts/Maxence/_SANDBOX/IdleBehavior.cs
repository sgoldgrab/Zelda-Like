﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : Behavior
{
    private float waitTime;
    [SerializeField] private float startWaitTime;

    private Vector2 checkpoint;

    [SerializeField] private float minX; [SerializeField] private float maxX; [SerializeField] private float minY; [SerializeField] private float maxY;

    public float enemyLastX;
    public float enemyLastY;

    void Start()
    {
        waitTime = startWaitTime;
        checkpoint = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    public override void EnemyBehavior() // patrols around using random checkpoints
    {
        if (Vector2.Distance(transform.position, checkpoint) <= 0.2f)
        {
            enemyState.isMoving = false;

            if (waitTime <= 0)
            {
                waitTime = startWaitTime;
                float clsMinX = transform.position.x + minX;
                float clsMaxX = transform.position.x + maxX;
                float clsMinY = transform.position.y + minY;
                float clsMaxY = transform.position.y + maxY;
                checkpoint = new Vector2(Random.Range(clsMinX, clsMaxX), Random.Range(clsMinY, clsMaxY));
            }

            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        else if (enemyState.enemyCanMove) // else and if the enemy can move...
        {
            enemyState.isMoving = true;

            transform.position = Vector2.MoveTowards(transform.position, checkpoint, enemyBaseSpeed * Time.deltaTime);

            enemyLastX = checkpoint.x - transform.position.x;
            enemyLastY = checkpoint.y - transform.position.y;
        }
    }
}
