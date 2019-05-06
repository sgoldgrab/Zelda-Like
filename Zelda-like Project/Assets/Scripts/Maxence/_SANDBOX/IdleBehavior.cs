using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : Behavior
{
    private float waitTime;
    [SerializeField] private float startWaitTime;

    private Vector2 checkpoint;

    [SerializeField] private float minX; [SerializeField] private float maxX; [SerializeField] private float minY; [SerializeField] private float maxY;

    public float enemyLastX { get; set; }
    public float enemyLastY { get; set; }

    [SerializeField] private float rayDist;

    private bool idle;
    [SerializeField] private float idleDuration;
    private float duration;

    void Start()
    {
        waitTime = startWaitTime;
        duration = idleDuration;
        checkpoint = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    void Update()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, checkpoint, rayDist);

        for (int h = 0; h < 0; h++)
        {
            Debug.Log(hits[h]);

            if (hits[h].collider != null && hits[h].transform.parent.parent.name != gameObject.name)
            {
                CalculateNewPosition();
            }
        }
    }

    public override void EnemyBehavior() // patrols around using random checkpoints
    {
        Debug.DrawRay(transform.position, checkpoint.normalized * rayDist, Color.red);

        if (enemyState.enemyCanMove && idle)
        {
            enemyLastX = checkpoint.x - transform.position.x;
            enemyLastY = checkpoint.y - transform.position.y;

            Idle();
        }

        else if (waitTime <= 0.0f)
        {
            waitTime = startWaitTime;

            CalculateNewPosition();
            idle = true;
            enemyState.isMoving = true;

            duration = idleDuration;
        }

        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    void Idle()
    {
        transform.position = Vector2.MoveTowards(transform.position, checkpoint, enemyBaseSpeed * Time.deltaTime);

        if (duration <= 0.0f)
        {
            idle = false;
            enemyState.isMoving = false;
        }

        else
        {
            duration -= Time.deltaTime;
        }
    }

    void CalculateNewPosition()
    {
        float clsMinX = transform.position.x + minX;
        float clsMaxX = transform.position.x + maxX;
        float clsMinY = transform.position.y + minY;
        float clsMaxY = transform.position.y + maxY;
        checkpoint = new Vector2(Random.Range(clsMinX, clsMaxX), Random.Range(clsMinY, clsMaxY));
    }
}
