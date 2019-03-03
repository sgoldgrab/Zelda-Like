using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilitiesBis : MonoBehaviour
{
    private float timer = 0f;
    [SerializeField] private float time;

    public GameObject[] spells;
    public GameObject[] potions;
   
    private GameObject theBluePrint;

    public GameObject[] spellBlueprints;
    public GameObject[] potionBlueprints;

    [SerializeField] private bool stanceOne = false;

    [SerializeField] private bool isReloading = false;

    private string buttonName;
    private bool inputPressed;
    private int index;

    private bool createBluePrint = true;

    private PlayerControllerEzEz playerController;

    void Start()
    {
        playerController = GetComponent<PlayerControllerEzEz>();
    }

    void Update()
    {
        WhatStance();
    }

    void WhatStance()
    {
        if (stanceOne)
        {
            if(Input.GetButtonDown("Potion1") && !isReloading)
            {
                index = 0;
                inputPressed = true;
                buttonName = "Potion1";
            }

            if (Input.GetButtonDown("Potion2") && !isReloading)
            {
                index = 1;
                inputPressed = true;
                buttonName = "Potion2";
            }

            if (Input.GetButtonDown("Potion3") && !isReloading)
            {
                index = 2;
                inputPressed = true;
                buttonName = "Potion3";
            }

            if (inputPressed)
            {
                Ability(index, true);
            }
        }

        else if (!stanceOne)
        {
            if (Input.GetButtonDown("Spell1") && !isReloading)
            {
                index = 0;
                inputPressed = true;
                buttonName = "Spell1";
            }

            if (Input.GetButtonDown("Spell2") && !isReloading)
            {
                index = 1;
                inputPressed = true;
                buttonName = "Spell2";
            }

            if (Input.GetButtonDown("Spell3") && !isReloading)
            {
                index = 2;
                inputPressed = true;
                buttonName = "Spell3";
            }

            if (inputPressed)
            {
                Ability(index, false);
            }
        }       
    }

    void Ability(int index, bool stance)
    {
        Blueprint(index, stance);

        if (Input.GetButtonUp(buttonName) && !isReloading)
        {
            Release(index, stance);
        }
    }

    void Release(int rIndex, bool rStance)
    {
        inputPressed = false;
        timer = 0;

        createBluePrint = true;
        Destroy(theBluePrint);

        playerController.canMove = true;

        if (rStance == false)
        {
            Instantiate(spells[rIndex], transform.position, Quaternion.identity);
        }

        else if (rStance == true)
        {
            Instantiate(potions[rIndex], transform.position, Quaternion.identity);
        }
    }

    void Blueprint(int bPIndex, bool bPStance)
    {
        if (timer > time)
        {
            playerController.canMove = false;

            if (createBluePrint)
            {
                if (bPStance == false)
                {
                    theBluePrint = Instantiate(spellBlueprints[bPIndex], transform.position, Quaternion.identity, transform);
                    createBluePrint = false;
                }

                else if (bPStance == true)
                {
                    theBluePrint = Instantiate(potionBlueprints[bPIndex], transform.position, Quaternion.identity, transform);
                    createBluePrint = false;
                }
            }

            //là il faut immobiliser le joueur, et lui permettre de diriger le blueprint avec le joystick gauche
        }

        else
        {
            timer += Time.deltaTime;
        }
    }
}
