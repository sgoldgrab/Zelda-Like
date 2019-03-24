using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy
{
    void Start()
    {
        HealthBarDisplay();
    }

    void Update()
    {
        if (currentBehavior == behavior.patrol)
        {
            IdleBehavior();
        }

        else if (currentBehavior == behavior.combat)
        {
            CombatBehavior();
        }
    }

    public override void CombatBehavior()
    {
        
    }
}
