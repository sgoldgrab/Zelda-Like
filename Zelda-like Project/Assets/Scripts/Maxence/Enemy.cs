using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected float sightRange;

    //ATTACK
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float attackCoolDown;
    [SerializeField] protected float attackRate;
    [SerializeField] protected float attackRateCoolDown;

    //IDLE
    private float idlePauseTime;
    [SerializeField] protected float idleStartPauseTime;
    public float idleWalkDistance; // useless

    [SerializeField] protected float minX;
    [SerializeField] protected float maxX;
    [SerializeField] protected float minY;
    [SerializeField] protected float maxY;

    protected Vector2 checkpoint;

    //ENUMS
    protected enum behavior { patrol, combat };
    protected behavior currentBehavior = behavior.patrol;

    //COMPONENTS
    protected EnemySpawner enemySpawner;

    protected GameObject[] healthSegment;

    public virtual void IdleBehavior()
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

    public virtual void CombatBehavior()
    {

    }

    public override void TakeDamage(float dmg, EnemyHealthBar healthBar)
    {
        canAttack = false;
        canMove = false;

        base.TakeDamage(dmg, healthBar);

        if(health <= 0)
        {
            enemySpawner.enemiesAlive -= 1;
        }
    }

    void Recover()
    {
        canMove = true;
        canAttack = true;

        isHit = false; // possibly useless /!\
    }

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
