using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnims : MonoBehaviour
{
    private Animator enemyAnimator;

    [SerializeField] private Transform playerTransform;

    void OnValidate()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
    }

    void LookAtPlayer()
    {
        if (transform.position.x >= playerTransform.position.x) { enemyAnimator.SetFloat("lastX", -1f); }
        if (transform.position.x <= playerTransform.position.x) { enemyAnimator.SetFloat("lastX", 1f); }
        if (transform.position.y >= playerTransform.position.y) { enemyAnimator.SetFloat("lastY", -1f); }
        if (transform.position.y <= playerTransform.position.y) { enemyAnimator.SetFloat("lastY", 1f); }
    }
}
