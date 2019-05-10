using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : MovementBehavior
{
    [SerializeField] private float minX; [SerializeField] private float maxX; [SerializeField] private float minY; [SerializeField] private float maxY;

    public float enemyLastX { get; set; }
    public float enemyLastY { get; set; }

    [SerializeField] private float rayDist;

    void Start()
    {
        pause = pauseTime;
        duration = moveDuration;
        direction = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    void Update()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, rayDist);

        for (int h = 0; h < 0; h++)
        {
            Debug.Log(hits[h]);

            if (hits[h].collider != null && hits[h].transform.parent.parent.name != gameObject.name)
            {
                //CalculateNewPosition();
            }
        }
    }

    public override void EnemyBehavior()
    {
        Debug.DrawRay(transform.position, direction.normalized * rayDist, Color.red);

        if (enemyState.enemyCanMove && moves)
        {
            enemyLastX = direction.x - transform.position.x;
            enemyLastY = direction.y - transform.position.y;
        }

        base.EnemyBehavior();
    }

    public override void NewDirection()
    {
        float clsMinX = transform.position.x + minX;
        float clsMaxX = transform.position.x + maxX;
        float clsMinY = transform.position.y + minY;
        float clsMaxY = transform.position.y + maxY;
        direction = new Vector2(Random.Range(clsMinX, clsMaxX), Random.Range(clsMinY, clsMaxY));
    }
}
