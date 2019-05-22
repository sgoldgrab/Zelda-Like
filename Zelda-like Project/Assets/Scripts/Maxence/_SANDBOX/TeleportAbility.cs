using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : CombatSkillUpdate
{
    [SerializeField] private float range;
    [SerializeField] private float speed;

    [SerializeField] private CombatSkillUpdate combatSkill;

    [SerializeField] private GameObject attackCollider;

    private Vector2 destination;

    public override void Skill(int ind)
    {
        base.Skill(ind);
    }

    public override void LateEffect()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (abDuration <= 0.0f)
        {
            foreach (Collider2D col in enemyState.enemyColliders) col.enabled = true;
        }

        base.LateEffect();
    }

    public override void AbilityAnimMethod()
    {
        Destination();

        activation = true;

        foreach (Collider2D col in enemyState.enemyColliders) col.enabled = false;

        base.AbilityAnimMethod();
    }

    void Destination()
    {
        Vector2 coordinates = enemyState.playerTransform.position - transform.position;
        Vector3 direction = coordinates.normalized;
        destination = enemyState.playerTransform.position + (direction * range);

        // Test Willem Unt Wieber
        float angle = (Mathf.Atan2(coordinates.x, coordinates.y) * -Mathf.Rad2Deg) + 90;

        attackCollider.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(destination, 1f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, infos[0].value);
    }
}
