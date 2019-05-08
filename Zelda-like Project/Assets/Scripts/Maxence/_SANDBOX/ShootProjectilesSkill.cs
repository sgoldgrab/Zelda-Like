using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectilesSkill : Skill
{
    [SerializeField] private int startRate;
    public int rate { get; private set; }

    [SerializeField] private float startWaitRate;
    public float waitRate { get; private set; } = 0.0f;

    [SerializeField] private GameObject fireBall;

    void Start()
    {
        rate = startRate;
    }

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
                enemyAnims.SkillAnim(animIndex);
                waitRate = startWaitRate;
                rate--;
            }

            else
            {
                waitRate -= Time.deltaTime;
            }
        }

        else if (passed == startRate)
        {
            rate = startRate;
            passed = 0;
            skillIsActive = false;
            enemyState.enemyCanMove = true;
        }
    }

    public override void AbilityAnimMethod() // FireBall
    {
        GameObject bullet = Instantiate(fireBall, transform.position, transform.rotation);
        bullet.GetComponent<FireBall>().SetPlayerPos(enemyState.playerTransform.position);

        base.AbilityAnimMethod();
    }
}
