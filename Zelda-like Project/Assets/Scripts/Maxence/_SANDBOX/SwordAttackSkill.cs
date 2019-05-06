﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackSkill : Skill
{
    [SerializeField] private float attackRange;
    [SerializeField] private int swordDamage;

    private Vector2 attackPosition;
    private Vector2 fixedAttackPos;
    [SerializeField] private float swordBlowZoneRadius;
    [SerializeField] private LayerMask thisIsThePlayer;

    [SerializeField] private int startRate;
    public int rate { get; private set; }

    [SerializeField] private float startAttackWaitRate;
    public float attackWaitRate { get; private set; } = 0.0f;

    private List<GameObject> thePlayer = new List<GameObject>();

    [SerializeField] private GameObject attackPos2;

    void Start()
    {
        additionalCooldown = 1.0f;
        rate = startRate;
    }

    void Update()
    {
        SwordAttackDirection();

        if (skillIsActive && enemyState.enemyCanUseSkill)
        {
            EnemyBehavior();
        }

        attackWaitRate -= Time.deltaTime;
    }

    public override void EnemyBehavior()
    {
        SwordAttack();
    }

    void SwordAttack()
    {
        if (rate > 0)
        {
            if (attackWaitRate <= 0.0f)
            {
                fixedAttackPos = attackPosition;
                enemyAnims.SkillAnim(animIndex);
                attackWaitRate = startAttackWaitRate;
                rate--;
            }
        }

        else
        {
            rate = startRate;
            skillIsActive = false;
            enemyState.enemyCanMove = true;
        }
    }

    public override void AbilityAnimMethod() // SwordBlow
    {
        //SwordBlow();

        Clear();
    }

    void SwordBlow()
    {
        Collider2D[] playerCollider = Physics2D.OverlapCircleAll(fixedAttackPos, swordBlowZoneRadius, thisIsThePlayer);

        for (int u = 0; u < playerCollider.Length; u++)
        {
            if (playerCollider[u] is BoxCollider2D)
            {
                playerCollider[u].transform.parent.parent.gameObject.GetComponent<PlayerState>().TakeDamage(swordDamage);
            }
        }
    }

    public void Clear()
    {
        thePlayer.Clear();
    }

    void SwordAttackDirection()
    {
        float attackX = enemyState.playerTransform.position.x - transform.position.x;
        float attackY = enemyState.playerTransform.position.y - transform.position.y;

        Vector2 attackCoordinates = new Vector2(attackX, attackY);
        Vector3 attackDir = attackCoordinates.normalized * attackRange;
        attackPosition = transform.position + attackDir;

        // Test Strauss Yona Gurzeit
        float angle = (Mathf.Atan2(attackX, attackY) * -Mathf.Rad2Deg) + 90;

        attackPos2.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = other.transform.parent.parent.gameObject;

            if (thePlayer.Count < 1)
            {
                player.GetComponent<PlayerState>().TakeDamage(1);
                thePlayer.Add(player);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(attackPosition, swordBlowZoneRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, infos[0].value);
    }
}
