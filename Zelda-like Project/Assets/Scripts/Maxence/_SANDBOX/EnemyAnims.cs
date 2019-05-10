using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnims : MonoBehaviour
{
    public Animator enemyAnimator { get; private set; }

    [SerializeField] private EnemyState enemyState;
    private IdleBehavior idleBehavior;
    private EnemyBehaviorsManager enemyBehaviorsManager;

    [SerializeField] private List<Skill> skillsAnimationMethods;

    [SerializeField] private int layerIndex;

    void Awake()
    {
        enemyAnimator = GetComponentInChildren<Animator>();

        skillsAnimationMethods = GetComponentInParent<EnemyBehaviorsManager>().theSkills;
        enemyBehaviorsManager = GetComponentInParent<EnemyBehaviorsManager>();
        idleBehavior = GetComponentInParent<IdleBehavior>();
    }

    void Start()
    {
        enemyAnimator.SetLayerWeight(layerIndex, 1);
    }

    void Update()
    {
        if (enemyBehaviorsManager.behavior == EnemyBehaviorsManager.Behaviors.idle) DirectionAnim();

        else if (enemyBehaviorsManager.behavior == EnemyBehaviorsManager.Behaviors.combat) LookAtPlayer();

        if (enemyState.health <= 0)
        {
            enemyAnimator.SetTrigger("isDead");
        }
    }

    void LookAtPlayer()
    {
        if (transform.position.x >= enemyState.playerTransform.position.x) { enemyAnimator.SetFloat("lastX", -1f); }
        if (transform.position.x <= enemyState.playerTransform.position.x) { enemyAnimator.SetFloat("lastX", 1f); }
        if (transform.position.y >= enemyState.playerTransform.position.y) { enemyAnimator.SetFloat("lastY", -1f); }
        if (transform.position.y <= enemyState.playerTransform.position.y) { enemyAnimator.SetFloat("lastY", 1f); }
    }

    public void DirectionAnim()
    {
        if (idleBehavior.enemyLastX > 0) { enemyAnimator.SetFloat("lastX", 1); }
        if (idleBehavior.enemyLastX < 0) { enemyAnimator.SetFloat("lastX", -1); }
        if (idleBehavior.enemyLastY > 0) { enemyAnimator.SetFloat("lastY", 1); }
        if (idleBehavior.enemyLastY < 0) { enemyAnimator.SetFloat("lastY", -1); }
    }

    public void MoveAnim(bool move)
    {
        if (enemyAnimator == null) return;

        if (move) { enemyAnimator.SetBool("isMoving", true); }
        else if (!move) { enemyAnimator.SetBool("isMoving", false); }
    }

    public void DamageAnim()
    {
        if (enemyState.health > 0)
        {
            enemyAnimator.SetTrigger("isHit");
        }
    }

    public void SkillAnim(int val)
    {
        enemyAnimator.SetInteger("ability", val);
        enemyAnimator.SetTrigger("useSkill");
    }

    /// Animation Events \\\

    public void OnDeath()
    {
        Destroy(transform.parent.gameObject);
    }

    public void Recover()
    {
        enemyState.enemyCanUseSkill = true;
        enemyState.enemyCanMove = true;
    }

    public void SkillAnimationEvent(string name)
    {
        foreach (Skill skill in GetComponentInParent<EnemyBehaviorsManager>().theSkills)
        {
            if (skill.abilityName == name)
            {
                skill.AbilityAnimMethod();
            }
        }

        foreach (Trigger trig in GetComponentInParent<EnemyBehaviorsManager>().theTriggers)
        {
            if (trig.abilityName == name)
            {
                trig.AbilityAnimMethod();
            }
        }
    }
}
