using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbility : Trigger
{
    [SerializeField] private int times;
    private int rate;

    [SerializeField] private float time;
    private float wait;

    [SerializeField] private float pushSpeed;

    [SerializeField] private float pushTime;
    private float pushDuration;

    void Start()
    {
        rate = times;
    }

    void Update()
    {
        if (skillIsActive && enemyState.enemyCanUseSkill || triggerIsActive)
        {
            EnemyBehavior();

            Parry();
        }
    }

    public override void EnemyBehavior()
    {
        if (rate > 0)
        {
            if (wait <= 0.0f)
            {
                enemyAnims.SkillAnim(animIndex);
                pushDuration = pushTime;
                enemyState.isProtected = true;
                wait = time;

                rate--;
            }

            else
            {
                wait -= Time.deltaTime;
            }
        }

        else
        {
            rate = times;
            skillIsActive = false;
            triggerIsActive = false;
            enemyState.enemyCanMove = true;
        }
    }

    void Parry()
    {
        if (enemyState.isProtected && enemyState.parry)
        {
            Vector2 pushDir = transform.position + new Vector3(enemyState.playerMovement.lastX, enemyState.playerMovement.lastY);
            Vector2 oppDir = enemyState.playerTransform.position - new Vector3(enemyState.playerMovement.lastX, enemyState.playerMovement.lastY);

            transform.position = Vector2.MoveTowards(transform.position, pushDir, pushSpeed * Time.deltaTime);
            enemyState.playerTransform.position = Vector2.MoveTowards(enemyState.playerTransform.position, oppDir, pushSpeed * Time.deltaTime);

            if (pushDuration <= 0.0f)
            {
                enemyState.parry = false;
            }

            else
            {
                pushDuration -= Time.deltaTime;
            }
        }
    }

    public override void AbilityAnimMethod()
    {
        enemyState.isProtected = false;
    }
}
