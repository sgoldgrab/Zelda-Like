using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public bool checkPoint = false;

    public bool canRespawn = false;

    [SerializeField] private GameObject player;
    private SpriteRenderer playerSprite;

    private PlayerMovement playerMovement;
    private PlayerAbilities playerAbilities;
    private PlayerAttack playerAttack;
    private PlayerStance playerStance;
    private PlayerInteraction playerInteraction;
    private Inventory inventory;

    public GameObject checkPointSpawn;

    private void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        playerAbilities = player.GetComponent<PlayerAbilities>();
        playerAttack = player.GetComponent<PlayerAttack>();
        playerStance = player.GetComponent<PlayerStance>();
        playerInteraction = player.GetComponent<PlayerInteraction>();
        inventory = player.GetComponent<Inventory>();

        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    private void OnDeath()
    {
        playerMovement.canMove = false;
        playerStance.canSwitch = false;
        playerAttack.canAttack = false;
        playerInteraction.canInteract = false;
        playerAbilities.canUseAbility = false;
        inventory.canUseConsumable = false;

        playerSprite.enabled = false;

        GameObject[] consumables = GameObject.FindGameObjectsWithTag("Consumables");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i =0; i < consumables.Length; i++)
        {
            Destroy(consumables[i]);
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }

    private void PlayerRespawn()
    {
        if(checkPoint && canRespawn)
        {
            player.transform.position = checkPointSpawn.transform.position;
            player.transform.rotation = Quaternion.identity;

            playerSprite.enabled = true;

            playerMovement.canMove = true;
            playerStance.canSwitch = true;
            playerAttack.canAttack = true;
            playerInteraction.canInteract = true;
            playerAbilities.canUseAbility = true;
            inventory.canUseConsumable = true;
        }

        if(!checkPoint && canRespawn)
        {
            player.transform.position = new Vector3(0, 0, 0);
            player.transform.rotation = Quaternion.identity;

            playerSprite.enabled = true;

            playerMovement.canMove = true;
            playerStance.canSwitch = true;
            playerAttack.canAttack = true;
            playerInteraction.canInteract = true;
            playerAbilities.canUseAbility = true;
            inventory.canUseConsumable = true;
        }

        //Faire repop les mobs et les consommables
    }
}

