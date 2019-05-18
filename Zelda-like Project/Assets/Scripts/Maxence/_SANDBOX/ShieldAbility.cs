using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbility : CombatSkillUpdate
{
    [SerializeField] private float pushSpeed;

    public override void Skill(int index)
    {
        if (rate > 0 && wait <= 0.0f) enemyState.isProtected = true;

        base.Skill(index);
    }

    public override void SkillUpdate()
    {
        if (rate > 0 && wait <= 0.0f && !isPlaying) activation = true; // we activate the Late Effect in advance, at the exact time the animation starts

        base.SkillUpdate();
    }

    public override void LateEffect()
    {
        //if (enemyState.parry) { // code down there }

        Vector2 pushDir = transform.position + new Vector3(enemyState.playerMovement.lastX, enemyState.playerMovement.lastY);
        Vector2 oppDir = enemyState.playerTransform.position - new Vector3(enemyState.playerMovement.lastX, enemyState.playerMovement.lastY);

        transform.position = Vector2.MoveTowards(transform.position, pushDir, pushSpeed * Time.deltaTime);
        enemyState.playerTransform.position = Vector2.MoveTowards(enemyState.playerTransform.position, oppDir, pushSpeed * Time.deltaTime);

        base.LateEffect();

        if (abDuration <= 0.0f) enemyState.parry = false;
    }

    public override void AbilityAnimMethod()
    {
        enemyState.isProtected = false;

        base.AbilityAnimMethod();
    }
}
