using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int health;
    public int maxHealth;

    public int damage;
    public int attackSpeed;

    public float speed;

    public enum Stance { stance1, stance2 } ;
    public Stance whatStance;

    public float sightRadius;

    public float cooldownReduction;

    public float potionDuration;

    public GameObject[] itemsInInventory;
    public int currentSlotTaken;
    public int pickUpSlot;

    public GameObject[] sephirothsInInventory;

    public float[] position;

    public PlayerData (PlayerState playerState)
    {
        health = playerState.health;
        maxHealth = playerState.maxHealth;
    }

    public PlayerData (PlayerAttack playerAttack)
    {
        damage = playerAttack.attackDamage;
        attackSpeed = playerAttack.attackSpeed;
    }

    public PlayerData (PlayerMovement playerMovement)
    {
        speed = playerMovement.playerSpeed;
    }

    public PlayerData (PlayerStance playerStance)
    {
        whatStance = playerStance.whatStance;
    }

    public PlayerData (PlayerSight playerSight)
    {
        sightRadius = playerSight.sightZoneRadius;
    }

    public PlayerData (PlayerAbilities playerAbilities)
    {
        cooldownReduction = playerAbilities.reduction;
    }

    public PlayerData (PotionsEffects potionsEffects)
    {
        potionDuration = potionsEffects.duration;
    }

    public PlayerData (Inventory inventory)
    {
        itemsInInventory = new GameObject[3];
        itemsInInventory[0] = inventory.consumables[0];
        itemsInInventory[1] = inventory.consumables[1];
        itemsInInventory[2] = inventory.consumables[2];
        currentSlotTaken = inventory.currentSlotsTaken;
        pickUpSlot = inventory.pickUpSlot;
    }

}
