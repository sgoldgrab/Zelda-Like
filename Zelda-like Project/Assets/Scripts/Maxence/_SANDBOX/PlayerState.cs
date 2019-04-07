using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int playerMaxHealth;
    [HideInInspector] public int playerHealth;

    [SerializeField] private PlayerAnims playerAnims;
    [SerializeField] private PlayerUI playerUI;

    void Start()
    {
        playerHealth = playerMaxHealth;
    }

    void Update() // TESTING ONLY
    {
        TestMethod();
    }

    public void TakeDamage(int dmg)
    {
        playerAnims.DamageAnim(); // the OnDeath() Method is activated through the playerAnims script, with the death animation.

        if (playerHealth <= 0) { return; }

        playerUI.UITakeDamage(playerHealth, dmg);
        playerHealth = Mathf.Clamp(playerHealth - dmg, 0, playerMaxHealth);
    }

    public void TakeHeal(int heal)
    {
        if(playerHealth >= playerMaxHealth) { return; }

        playerHealth = Mathf.Clamp(playerHealth + heal, 0, playerMaxHealth);
        playerUI.UITakeHealth(playerHealth, heal);
    }

    public void OnDeath() // activated via the playerAnims script.
    {
        Destroy(gameObject);
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
