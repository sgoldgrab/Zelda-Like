using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SwordCombatInfos : CombatInfos
{
    public int damage;
    public float attackMoveDistance;
}

public class SwordAttackSkill : CombatSkillUpdate
{
    [SerializeField] private float attackMoveRange;
    [SerializeField] private int swordDamage;

    private Vector2 attackPosition;
    [SerializeField] private float swordBlowZoneRadius;
    [SerializeField] private LayerMask thisIsThePlayer;

    private List<GameObject> thePlayer = new List<GameObject>();

    [SerializeField] private GameObject attackPos2;

    public override void Skill(int index)
    {
        base.Skill(index);
    }

    public override void SkillUpdate()
    {
        // we activate the Late Effect in advance AND we set the direction of the attack, at the exact time the animation starts
        if (rate > 0 && wait <= 0.0f && !isPlaying) { SwordAttackDirection(); activation = true; }

        base.SkillUpdate();
    }

    public override void LateEffect()
    {
        transform.position = Vector2.MoveTowards(transform.position, attackPosition, enemyBaseSpeed * Time.deltaTime);

        base.LateEffect();
    }

    public override void AbilityAnimMethod() // Clear
    {
        thePlayer.Clear();
        base.AbilityAnimMethod();
    }

    void SwordAttackDirection()
    {
        float attackX = enemyState.playerTransform.position.x - transform.position.x;
        float attackY = enemyState.playerTransform.position.y - transform.position.y;

        Vector2 attackCoordinates = new Vector2(attackX, attackY);
        Vector3 attackDir = attackCoordinates.normalized * attackMoveRange;
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

    //OLD SCRIPTING

    void SwordBlow()
    {
        Collider2D[] playerCollider = Physics2D.OverlapCircleAll(attackPosition, swordBlowZoneRadius, thisIsThePlayer);

        for (int u = 0; u < playerCollider.Length; u++)
        {
            if (playerCollider[u] is BoxCollider2D)
            {
                playerCollider[u].transform.parent.parent.gameObject.GetComponent<PlayerState>().TakeDamage(swordDamage);
            }
        }
    }
}
