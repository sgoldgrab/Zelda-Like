using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : CombatSkillUpdate
{
    private float cooldown = 0.0f;
    [SerializeField] private float cooldownTime;

    private Vector2 direction;

    private enum WhatDash
    {
        Simple,
        Mixed,
        Lateral,
        Attack
    }
    [SerializeField] private WhatDash dash;

    public override void Skill(int index)
    {
        Direction();

        base.Skill(index);
    }

    public override void SkillUpdate(int uIndex)
    {
        if (rate > 0 && wait <= 0.0f && !isPlaying) activation = true; // we activate the Late Effect in advance, at the exact time the animation starts

        base.SkillUpdate(uIndex);
    }

    public override void LateEffect()
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, enemyBaseSpeed * Time.deltaTime);

        base.LateEffect();
    }

    public override void AbilityAnimMethod()
    {
        base.AbilityAnimMethod();
    }

    void Direction()
    {
        Vector2 dashDirection = transform.position - enemyState.playerTransform.position;
        Vector3 normalizedDirection = dashDirection.normalized;
        Vector3 randomizedDirection = LateralDash(normalizedDirection);

        if (dash == WhatDash.Simple) direction = transform.position + normalizedDirection ;
        if (dash == WhatDash.Mixed) direction = transform.position + normalizedDirection + randomizedDirection;
        if (dash == WhatDash.Lateral) direction = transform.position + randomizedDirection;

        if (dash == WhatDash.Attack)
        {
            Vector3 breakthrough = enemyState.playerTransform.position - transform.position;
            direction = transform.position + breakthrough.normalized;
        }
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, infos[0].value);
    }
}
