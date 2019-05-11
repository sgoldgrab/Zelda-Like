using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public bool checkPoint = false;

    public bool canRespawn = false;

    [SerializeField] private GameObject player;
    private SpriteRenderer playerSprite;

    [SerializeField] private GameObject gameManager;
    private GameManager managerScript;

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

        managerScript = gameManager.GetComponent<GameManager>();
    }

    private void OnDeath()
    {
        playerMovement.canMove = false;
        playerStance.canSwitch = false;
        playerAttack.canAttack = false;
        playerInteraction.canInteract = false;
        playerAbilities.canUseAbilities = false;
        inventory.canUseConsumables = false;

        playerSprite.enabled = false;

        managerScript.Reset();
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
            playerAbilities.canUseAbilities = true;
            inventory.canUseConsumables = true;
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
            playerAbilities.canUseAbilities = true;
            inventory.canUseConsumables = true;
        }

        managerScript.Set();
    }
}

