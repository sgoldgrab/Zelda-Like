﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Variables
    public float inputHor;
    public float inputVer;

    public float timer = 05f;

    public bool isDead = false;

    private PlayerStance stanceScript;

    private PlayerAttack attackScript;

    private Interact interactionScript;

    private Inventory inventoryScript;

    private AbilitiesPlayer abilitiesScript;

    [SerializeField] private GameObject player;
    #endregion

    public GameObject prefab; //A ENLEVER

    private Health playerScript; //A ENLEVER

    private void Awake()
    {
        
        stanceScript = player.GetComponent<PlayerStance>();

        attackScript = player.GetComponent<PlayerAttack>();

        abilitiesScript = player.GetComponent<AbilitiesPlayer>();

        interactionScript = player.GetComponent<Interact>();

        inventoryScript = player.GetComponent<Inventory>();

        //ENLEVE
        playerScript = player.GetComponent<PlayerStatistics>().healthStats;

    }

    private void Update()
    {

        if(!isDead)
        {

            GetInput();

        }

    }

    private void GetInput()
    {
        #region A ENLEVER
        if(Input.GetKeyDown(KeyCode.T))
        {

            Instantiate(prefab, new Vector2(3, 1), Quaternion.identity);

        }

        if(Input.GetKeyDown(KeyCode.Y))
        {

            playerScript.TakeDamage(1);

        }
        #endregion

        #region Movement
        inputHor = Input.GetAxisRaw("Horizontal");
        inputVer = Input.GetAxisRaw("Vertical");
        #endregion

        #region Stance
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.E))
        {

            stanceScript.SwitchStance();

        }
        #endregion

        #region Attack
        /*if(Input.GetButtonDown("Fire2"))
        {

            attackScript.LaunchAttack();

        }*/
        #endregion

        #region Interaction
        if(Input.GetKeyDown(KeyCode.Space) && interactionScript.isInRangeToInteract)
        {

            interactionScript.Interaction();

        }
        #endregion

        #region Abilities
        if(Input.GetButtonDown("Spell1") || Input.GetKeyDown(KeyCode.Alpha1))
        {

            abilitiesScript.AbilityOne();

        }

        if(/*Input.GetButtonDown("Ability2") ||*/ Input.GetKeyDown(KeyCode.Alpha2))
        {

            abilitiesScript.AbilityTwo();

        }

        if(/*Input.GetButtonDown("Ability3") ||*/ Input.GetKeyDown(KeyCode.Alpha3))
        {

            abilitiesScript.AbilityThree();

        }
        #endregion

        #region Consumables
        if(Input.GetKeyDown(KeyCode.W))
        {

            inventoryScript.UseConsumable(0);

        }

        if(Input.GetKeyDown(KeyCode.X))
        {

            inventoryScript.UseConsumable(1);

        }

        if(Input.GetKeyDown(KeyCode.C))
        {

            inventoryScript.UseConsumable(2);

        }
        #endregion

    }

}
