using System.Collections;
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

    private AbilitiesPlayer abilitiesScript;

    [SerializeField] private GameObject player;
    #endregion

    private void Awake()
    {
        
        stanceScript = player.GetComponent<PlayerStance>();

        attackScript = player.GetComponent<PlayerAttack>();

        abilitiesScript = player.GetComponent<AbilitiesPlayer>();

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
        /*if()
        {



        }*/
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

    }

}
