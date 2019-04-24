using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConditionType { Lesser, Greater, None }

[System.Serializable]
public class ConditionInfo
{
    public ConditionType conditionType;
    public float value;
    public string text;
}

public class EnemyConditions : MonoBehaviour
{
    [SerializeField] private EnemyState enemyState;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private EnemyAnims enemyAnims;

    [SerializeField] private PlayerStance playerStance;

    void Start()
    {
        playerStance = FindObjectOfType<PlayerStance>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        Debug.Log(playerStance + " " + enemySpawner);
    }

    public bool CheckCondition(Conditions cond, ConditionInfo info)
    {
        switch (cond)
        {
            case Conditions.DistanceToPlayer: // Trigger or Skill Behavior
                if (info.conditionType.Equals(ConditionType.Greater))
                {
                    if (Vector2.Distance(transform.position, enemyState.playerTransform.position) >= info.value) { return true; }
                    return false;
                }
                else
                {
                    if (Vector2.Distance(transform.position, enemyState.playerTransform.position) <= info.value) { return true; }
                    return false;
                }

            case Conditions.NumberOfEnemies: // Trigger or Skill Behavior
                if (info.conditionType.Equals(ConditionType.Greater))
                {
                    if (enemySpawner.enemiesAlive >= info.value) { return true; }
                    return false;
                }
                else
                {
                    if (enemySpawner.enemiesAlive <= info.value) { return true; }
                    return false;
                }

            case Conditions.IsAttacked: // Trigger
                if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.Mouse0)) { return true; }
                return false;

            case Conditions.HasTakenDamage: // Trigger or Skill Behavior
                if (enemyAnims.enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName(info.text)) { return true; }
                return false;

            case Conditions.PlayerUseAnAbility: // Trigger
                /*if (Input.GetButtonDown(playerStance.input)) { return true; }
                return false;*/
                break;

            case Conditions.PlayerSwitchStance: // Trigger
                if (Input.GetButtonDown(playerStance.input)) { return true; }
                return false;

            case Conditions.None:
                return true;

            default:
                break;
        }

        return false;
    }
}
