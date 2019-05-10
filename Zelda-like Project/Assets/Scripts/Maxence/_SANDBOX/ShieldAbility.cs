using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbility : CombatSkillNew
{
    [SerializeField] private float pushSpeed;

    public override void EnemyBehavior()
    {
        if (rate > 0 && wait <= 0.0f) enemyState.isProtected = true;

        base.EnemyBehavior();
    }

    public override void LateEffect()
    {
        //if (enemyState.parry) { // code down there }

        Vector2 pushDir = transform.position + new Vector3(enemyState.playerMovement.lastX, enemyState.playerMovement.lastY);
        Vector2 oppDir = enemyState.playerTransform.position - new Vector3(enemyState.playerMovement.lastX, enemyState.playerMovement.lastY);

        transform.position = Vector2.MoveTowards(transform.position, pushDir, pushSpeed * Time.deltaTime);
        enemyState.playerTransform.position = Vector2.MoveTowards(enemyState.playerTransform.position, oppDir, pushSpeed * Time.deltaTime);

        base.LateEffect();

        if (duration <= 0.0f) enemyState.parry = false;
    }

    public override void AbilityAnimMethod()
    {
        enemyState.isProtected = false;

        base.AbilityAnimMethod();
    }
}
