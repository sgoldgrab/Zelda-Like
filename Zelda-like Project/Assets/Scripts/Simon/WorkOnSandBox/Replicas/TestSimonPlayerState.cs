using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSimonPlayerState : EntityState
{
    [SerializeField] private PlayerAnims playerAnims;
    [SerializeField] private EntityUI playerUI;

    public bool isImmune = false;

    void Update() // TESTING ONLY
    {
        //TestMethod();
    }

    public override void TakeDamage(int dmg)
    {
        if (health <= 0) { return; }

        if(!isImmune)
        {
            playerUI.UITakeDamage(health, dmg);

            base.TakeDamage(dmg);

            Debug.Log(health);

            playerAnims.DamageAnim(); // the OnDeath() Method is activated through the playerAnims script, with the death animation.
        }
    }

    public override void TakeHeal(int heal)
    {
        if (health >= maxHealth) { return; }

        playerUI.UITakeHealth(health, heal);

        base.TakeHeal(heal);

        Debug.Log(health);
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
