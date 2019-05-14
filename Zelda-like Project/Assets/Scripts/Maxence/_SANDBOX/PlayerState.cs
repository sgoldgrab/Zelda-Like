using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : EntityState
{
    [SerializeField] private PlayerAnims playerAnims;
    [SerializeField] private EntityUI playerUI;

    public int immunities { get; set; } = 0;
    public int damageCount { get; set; } = 0;

    private bool playerIsDead;

    [SerializeField] private Collider2D[] colliders;
    public Collider2D[] playerColliders { get => colliders; private set => colliders = value; }

    void Update() // TESTING ONLY
    {
        TestMethod();
    }

    public override void TakeDamage(int dmg)
    {
        if (immunities > 0) { damageCount++; return; }

        for (int d = 0; d < dmg; d++)
        {
            if (!playerIsDead)
            {
                if (health == 1) playerIsDead = true;

                playerUI.UITakeDamage(health, 1);

                base.TakeDamage(1);
            }
        }

        playerAnims.DamageAnim(); // the OnDeath() Method is activated through the playerAnims script, with the death animation.
    }

    public override void TakeHeal(int heal)
    {
        for (int h = 0; h < heal; h++)
        {
            if (health >= maxHealth) { return; }

            playerUI.UITakeHealth(health, 1);

            base.TakeHeal(1);
        }
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
