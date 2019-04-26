using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehavior : Behavior
{
    [SerializeField] private EnemyAnims enemyAnims;

    [SerializeField] private float minDist;
    [SerializeField] private float chaseSpeed;

    public override void EnemyBehavior()
    {
        if (Vector2.Distance(transform.position, enemyState.playerTransform.position) > minDist)
        {
            enemyAnims.MoveAnim(true);
            transform.position = Vector2.MoveTowards(transform.position, enemyState.playerTransform.position, chaseSpeed * Time.deltaTime);
        }

        else
        {
            enemyAnims.MoveAnim(false);
        }
    }
}
