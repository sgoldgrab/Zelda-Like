using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : HealthManager
{
    public override void TakeDamage(float dmg, EnemyHealthBar healthBar)
    {
        if (immunity)
        {
            resistance += dmg;
            return;
        }

        base.TakeDamage(dmg, healthBar);
    }
}
