using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectilesSkill : Skill
{
    [SerializeField] private EnemyAnims enemyAnims;

    [SerializeField] private int startRate;
    public int rate { get; private set; }

    [SerializeField] private float startWaitRate;
    public float waitRate { get; private set; } = 0.0f;

    [SerializeField] private GameObject fireBall;

    void Update()
    {
        if (skillIsActive)
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

                //FireBall();
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

    public override void SkillAnimMethod() // FireBall
    {
        GameObject bullet = Instantiate(fireBall, transform.position, transform.rotation);
        bullet.GetComponent<FireBall>().SetPlayerPos(enemyState.playerTransform.position);

        waitRate = startWaitRate;
        rate--;
    }
}
