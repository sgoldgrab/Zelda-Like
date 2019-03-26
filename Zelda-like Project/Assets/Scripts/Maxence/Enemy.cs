using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    //SIGHT
    [SerializeField] protected float sightRange;

    //ATTACK
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float attackCoolDown;
    [SerializeField] protected float attackRate;
    [SerializeField] protected float attackRateCoolDown;

    //ENUMS
    protected enum behavior { patrol, combat };
    protected behavior currentBehavior = behavior.patrol;

    //COMPONENTS
    protected EnemySpawner enemySpawner;

    protected GameObject[] healthSegment;

    public virtual void HealthBarDisplay() // Move it to the Enemy Health Bar script
    {
        int multiple = 1;
        float offsetX = 0.0f;
        int index = 0;

        foreach(GameObject prefab in healthSegment)
        {
            Instantiate(healthSegment[index], new Vector2(transform.position.x + offsetX, transform.position.y), Quaternion.identity);
            offsetX = 0.0f;
            index++;
            if (index%2 == 1) //odd
            {
                offsetX += 0.4f * multiple;
            }
            else if (index%2 == 0) //even
            {
                offsetX -= 0.4f * multiple;
                multiple++;
            }
        }
    }
}
