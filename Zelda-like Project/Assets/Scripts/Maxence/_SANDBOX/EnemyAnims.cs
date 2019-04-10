using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnims : MonoBehaviour
{
    private Animator enemyAnimator;

    [SerializeField] private Transform playerTransform;

    [SerializeField] private EnemyState enemyState;

    void OnValidate()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        LookAtPlayer();
    }

    void LookAtPlayer()
    {
        if (transform.position.x >= playerTransform.position.x) { enemyAnimator.SetFloat("lastX", -1f); }
        if (transform.position.x <= playerTransform.position.x) { enemyAnimator.SetFloat("lastX", 1f); }
        if (transform.position.y >= playerTransform.position.y) { enemyAnimator.SetFloat("lastY", -1f); }
        if (transform.position.y <= playerTransform.position.y) { enemyAnimator.SetFloat("lastY", 1f); }
    }

    public void MoveAnim(bool move)
    {
        if (move) { enemyAnimator.SetBool("isMoving", true); }
        else if (!move) { enemyAnimator.SetBool("isMoving", false); }
    }

    public void DamageAnim()
    {
        if (enemyState.health > 0)
        {
            enemyAnimator.SetTrigger("templarIsHit");
        }

        else if (enemyState.health <= 0)
        {
            enemyAnimator.SetTrigger("templarIsDead");
        }
    }

    public void AttackAnim()
    {
        enemyAnimator.SetTrigger("templarAttacks");
    }
}
