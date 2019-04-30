using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDamageZonesSkill : Skill
{
    [SerializeField] private int startRate;
    public int rate { get; private set; }

    [SerializeField] private float startWaitRate;
    public float waitRate { get; private set; } = 0.0f;

    [SerializeField] private EnemyAnims enemyAnims;

    [SerializeField] private GameObject areaOfEffect;

    void Update()
    {
        if (skillIsActive && enemyState.enemyCanUseSkill)
        {
            EnemyBehavior();
        }
    }

    public override void EnemyBehavior()
    {
        if (rate > 0)
        {
            if (waitRate <= 0.1)
            {
                enemyAnims.AttackAnim();
                waitRate = startWaitRate;
                rate--;
            }

            else
            {
                waitRate -= Time.deltaTime;
            }
        }

        else
        {
            rate = startRate;
            skillIsActive = false;
            enemyState.enemyCanMove = true;
        }
    }

    public override void SkillAnimMethod()
    {
        Vector2 desiredPos = enemyState.playerTransform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));

        GameObject aOE = Instantiate(areaOfEffect, desiredPos, transform.rotation);
    }
}
