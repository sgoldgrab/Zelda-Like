using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : Trigger
{
    private int rate;
    [SerializeField] private int times;

    private float wait;
    [SerializeField] private float time;

    private float cooldown = 0.0f;
    [SerializeField] private float cooldownTime;

    private float duration;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashSpeed;

    private bool canDash = false;

    private Vector2 desiredPosition;

    private enum WhatDash
    {
        Simple,
        Mixed,
        Lateral
    }
    [SerializeField] private WhatDash dash;

    void Start() { rate = times; }

    void Update()
    {
        if (skillIsActive && enemyState.enemyCanUseSkill || triggerIsActive && cooldown <= 0.0f)
        {
            EnemyBehavior();

            Dash();
        }

        else cooldown -= Time.deltaTime;
    }

    public override void EnemyBehavior()
    {
        if (rate > 0)
        {
            if (wait <= 0.0f)
            {
                Direction();

                enemyAnims.SkillAnim(animIndex);
                duration = dashDuration;
                canDash = true;
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
            cooldown = cooldownTime;
            skillIsActive = false;
            triggerIsActive = false;
            enemyState.enemyCanMove = true;
        }
    }

    void Dash()
    {
        if (canDash)
        {
            transform.position = Vector2.MoveTowards(transform.position, desiredPosition, dashSpeed * Time.deltaTime);

            if (duration <= 0.0f)
            {
                canDash = false;
            }

            else
            {
                duration -= Time.deltaTime;
            }
        }
    }

    void Direction()
    {
        Vector2 dashDirection = transform.position - enemyState.playerTransform.position;
        Vector3 normalizedDirection = dashDirection.normalized;
        Vector3 randomizedDirection = LateralDash(normalizedDirection);

        if (dash == WhatDash.Simple) desiredPosition = transform.position + normalizedDirection ;
        if (dash == WhatDash.Mixed) desiredPosition = transform.position + normalizedDirection + randomizedDirection;
        if (dash == WhatDash.Lateral) desiredPosition = transform.position + randomizedDirection;
    }

    Vector2 LateralDash(Vector2 dir)
    {
        float[] coordinates = new float[2];
        coordinates[0] = Mathf.Sign(dir.x); // x
        coordinates[1] = Mathf.Sign(dir.y); // y

        int random = Random.Range(0, 2);
        coordinates[random] = coordinates[random] * -1;

        Vector2 lateralDir = new Vector2(coordinates[0], coordinates[1]);
        return lateralDir;
    }

    public override void AbilityAnimMethod()
    {
        //
    }
}
