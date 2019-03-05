﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilitiesBis : MonoBehaviour
{
    private float timer = 0f;
    private float timer2 = 0f;

    [SerializeField] private float time2;

    [SerializeField] private float time;

    public GameObject[] spells;
    public GameObject[] potions;

    public PlayerDormantEffects[] potionsEffects;
   
    private GameObject theBluePrint;

    public GameObject[] spellBlueprints;
    public GameObject[] potionBlueprints;

    public bool stanceOne = false;
    private bool doubleTap = false;

    private bool[] cooldownIsOver = new bool[6];
    private float[] coolDownTime = new float[6];
    [SerializeField] private float[] startCoolDownTime;

    private string buttonName;
    private bool inputPressed;
    private int index;

    private bool createBluePrint = true;

    private PlayerControllerEzEz playerController;

    private PlayerDormantEffects playerDormants;

    private Vector2 transformPos;
    public Vector2 aimPos;
    [SerializeField] private float aimDistance;

    void Start()
    {
        playerController = GetComponent<PlayerControllerEzEz>();

        for(int y = 0; y < 6; y++)
        {
            cooldownIsOver[y] = true;
        }

        for(int x = 0; x < 6; x++) //pas utile
        {
            coolDownTime[x] = startCoolDownTime[x];
        }

        //potionsEffects[0] = playerDormants.Pot1Effect();

    }

    void Update()
    {
        transformPos = transform.position;

        CoolDown();

        InputManager();
    }

    void InputManager()
    {
        if (stanceOne)
        {
            doubleTap = true;

            if(Input.GetButtonDown("Potion1"))
            {
                if (cooldownIsOver[0])
                {
                    index = 0;
                    inputPressed = true;
                    buttonName = "Potion1";
                }
            }

            if (Input.GetButtonDown("Potion2"))
            {
                if (cooldownIsOver[1])
                {
                    index = 1;
                    inputPressed = true;
                    buttonName = "Potion2";
                }                
            }

            if (Input.GetButtonDown("Potion3"))
            {
                if (cooldownIsOver[2])
                {
                    index = 2;
                    inputPressed = true;
                    buttonName = "Potion3";
                }                
            }

            if (inputPressed)
            {
                Ability(index, true, aimDistance);
            }
        }

        else if (!stanceOne)
        {
            doubleTap = false;

            if (Input.GetButtonDown("Spell1"))
            {
                if (cooldownIsOver[3])
                {
                    index = 0;
                    inputPressed = true;
                    buttonName = "Spell1";
                }                
            }

            if (Input.GetButtonDown("Spell2"))
            {
                if (cooldownIsOver[4])
                {
                    index = 1;
                    inputPressed = true;
                    buttonName = "Spell2";
                }                
            }

            if (Input.GetButtonDown("Spell3"))
            {
                if (cooldownIsOver[5])
                {
                    index = 2;
                    inputPressed = true;
                    buttonName = "Spell3";
                }                
            }

            if (inputPressed)
            {
                Ability(index, false, aimDistance);
            }
        }
    }

    void CoolDown()
    {
        for(int i = 0; i < 6; i++)
        {
            if (coolDownTime[i] <= 0.1f)
            {
                cooldownIsOver[i] = true;
            }

            else
            {
                coolDownTime[i] -= Time.deltaTime;
            }
        }        
    }

    void Ability(int index, bool stance, float aBDistance)
    {
        AimDirection(aBDistance);

        Blueprint(index, stance, aBDistance);

        if (Input.GetButtonUp(buttonName))
        {
            if (doubleTap)
            {
                if (timer > 0 && Input.GetButtonDown(buttonName))
                {

                    Drink();

                }

                else
                {

                    timer2 -= Time.deltaTime;

                }

                if (timer <= 0f)
                {
                    doubleTap = false;
                }
            }

            else if (!doubleTap)
            {
                Release(index, stance);
            }            
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
            cooldownIsOver[rIndex + 3] = false;
            coolDownTime[rIndex + 3] = startCoolDownTime[rIndex + 3];

            GameObject spell = Instantiate(spells[rIndex], transformPos + aimPos, Quaternion.identity);

            //ONLY SPELL 1
            if (spell.GetComponent<SpellOne>() == null) return;
            else { spell.GetComponent<SpellOne>().SetPositions(aimPos); }
        }

        else if (rStance == true)
        {
            cooldownIsOver[rIndex] = false;
            coolDownTime[rIndex] = startCoolDownTime[rIndex];

            GameObject potion = Instantiate(potions[rIndex], transformPos + aimPos, Quaternion.identity);
        }
    }

    void Drink()
    {

        inputPressed = false;

        timer2 = time2;

        

    }

    void Blueprint(int bPIndex, bool bPStance, float bPDistance)
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

            else
            {                
                theBluePrint.transform.position = transformPos + aimPos;
            }

            //là il faut immobiliser le joueur, et lui permettre de diriger le blueprint avec le joystick gauche
        }

        else
        {
            timer += Time.deltaTime;
        }
    }

    void AimDirection(float distance)
    {
        if (playerController.lastX != 0 || playerController.lastY != 0)
        {
            float posX = playerController.lastX;
            float posY = playerController.lastY;

            Vector2 rawAimCoordinates = new Vector2(posX, posY);
            aimPos = rawAimCoordinates * distance;
        }
    }
}
