using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Variables
    public float inputHor;
    public float inputVer;

    public bool isDead = false;

    private PlayerStance stanceScript;

    private PlayerAttack attackScript;

    [SerializeField] private GameObject player;
    #endregion

    private void Awake()
    {
        
        stanceScript = player.GetComponent<PlayerStance>();

        attackScript = player.GetComponent<PlayerAttack>();

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
        /*if(Input.GetButtonDown("Ability1"))
        {

            //AbilityScript

        }

        if(Input.GetButtonDown("Ability2"))
        {

            //AbilityScript

        }

        if(Input.GetButtonDown("Ability3"))
        {

            //AbilityScript

        }*/
        #endregion

    }

}
