using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnims : MonoBehaviour
{
    public Animator enemyAnimator { get; private set; }
    public Animation enemyAnim { get; private set; }

    [SerializeField] private EnemyState enemyState;

    [SerializeField] private List<Skill> skillsAnimationMethods;

    void OnValidate()
    {
        enemyAnimator = GetComponentInChildren<Animator>();

        skillsAnimationMethods = GetComponentInParent<EnemyBehaviorsManager>().theSkills;
    }

    void Update()
    {
        LookAtPlayer();
    }

    void LookAtPlayer()
    {
        if (transform.position.x >= enemyState.playerTransform.position.x) { enemyAnimator.SetFloat("lastX", -1f); }
        if (transform.position.x <= enemyState.playerTransform.position.x) { enemyAnimator.SetFloat("lastX", 1f); }
        if (transform.position.y >= enemyState.playerTransform.position.y) { enemyAnimator.SetFloat("lastY", -1f); }
        if (transform.position.y <= enemyState.playerTransform.position.y) { enemyAnimator.SetFloat("lastY", 1f); }
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
            enemyAnimator.SetTrigger("isHit");
        }

        else if (enemyState.health <= 0)
        {
            enemyAnimator.SetTrigger("isDead");
        }
    }

    public void AttackAnim()
    {
        enemyAnimator.SetTrigger("attacks");
    }

    /// Animation Events \\\

    public void OnDeath()
    {
        Destroy(gameObject);
    }

    public void Recover()
    {
        enemyState.enemyCanUseSkill = true;
        enemyState.enemyCanMove = true;
    }

    public void SkillAnimationEvent(string name)
    {
        foreach (Skill skill in skillsAnimationMethods)
        {
            if (skill.skillName == name)
            {
                Debug.Log("it works");

                skill.SkillAnimMethod();
            }
        }
    }
}
