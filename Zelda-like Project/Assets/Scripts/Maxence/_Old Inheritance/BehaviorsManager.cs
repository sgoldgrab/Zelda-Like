using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorsManager : Enemy
{
    //private enum CombatBehaviors { patrol, chase };
    //private CombatBehaviors combatBehavior = CombatBehaviors.patrol; --> replace in the "specific enemy stats" script, that inherit from "enemy".

    void Start()
    {
        CircleCollider2D sightCollider = GetComponentInChildren<CircleCollider2D>();
        sightCollider.radius = sightRange;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentBehavior = behavior.combat;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentBehavior = behavior.patrol;
        }
    }
}
