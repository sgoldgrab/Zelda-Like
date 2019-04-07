using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : EntityState
{
    [SerializeField] private PlayerAnims playerAnims;
    [SerializeField] private PlayerUI playerUI;

    void Update() // TESTING ONLY
    {
        TestMethod();
    }

    public override void TakeDamage(int dmg)
    {
        playerAnims.DamageAnim(); // the OnDeath() Method is activated through the playerAnims script, with the death animation.

        if (health <= 0) { return; }

        playerUI.UITakeDamage(health, dmg);

        base.TakeDamage(dmg);
    }

    public override void TakeHeal(int heal)
    {
        base.TakeHeal(heal);

        if(health >= maxHealth) { return; }

        playerUI.UITakeHealth(health, heal);
    }

    void TestMethod() // TESTING ONLY
    {
        if (Input.GetButtonDown("Test1"))
        {
            TakeDamage(1);
        }

        if (Input.GetButtonDown("Test2"))
        {
            TakeHeal(1);
        }
    }
}
