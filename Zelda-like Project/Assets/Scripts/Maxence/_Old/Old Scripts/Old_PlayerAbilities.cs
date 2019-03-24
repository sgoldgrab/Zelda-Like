using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old_PlayerAbilities : MonoBehaviour
{
    public GameObject[] spells;
    public GameObject[] potions;

    private float timer = 0f;

    private bool[] buttonPressed = new bool[3];

    private string[] spellButtonName = new string[3];
    private string[] potionButtonName = new string[3];

    private GameObject theBluePrint;

    public GameObject[] spellBlueprints;
    public GameObject[] potionBlueprints;

    [SerializeField]
    private bool stanceOne = false;
    //private enum whatStance { stanceOne, stanceTwo }
    //private whatStance currentStance = whatStance.stanceOne;

    [SerializeField]
    private bool isReloading = false;

    void Start()
    {
        //GetComponent<PlayerController>();

        spellButtonName[0] = "Spell1";
        spellButtonName[1] = "Spell2";
        spellButtonName[2] = "Spell3";

        potionButtonName[0] = "Potion1";
        potionButtonName[1] = "Potion2";
        potionButtonName[2] = "Potion3";

        buttonPressed[0] = false;
        buttonPressed[1] = false;
        buttonPressed[2] = false;
    }

    void Update()
    {
        WhatStance();
    }

    void WhatStance()
    {
        if (stanceOne)
        {
            Instantiate(potionButtonName[0], 0, potionBlueprints);
            Instantiate(potionButtonName[1], 1, potionBlueprints);
            Instantiate(potionButtonName[2], 2, potionBlueprints);
        }

        else if (!stanceOne)
        {
            Debug.Log(spellButtonName[0]);
            Instantiate(spellButtonName[0], 0, spellBlueprints);
            Instantiate(spellButtonName[1], 1, spellBlueprints);
            Instantiate(spellButtonName[2], 2, spellBlueprints);
        }
    }

    void Instantiate(string button, int index, GameObject[] list)
    {
        if (Input.GetButtonDown(button) && !isReloading)
        {
            buttonPressed[index] = true;

            //Reminder : intégrer bool pour bloquer le mouvement et le switch de stance
        }

        if (buttonPressed[index])
        {
            BlueprintTimer(index, list);
        }

        if (Input.GetButtonUp(button) && !isReloading)
        {
            Release(index, list);
        }
    }

    void Release(int rIndex, GameObject[] rList)
    {
        buttonPressed[rIndex] = false;
        timer = 0;

        Destroy(theBluePrint);

        if (rList == spellBlueprints)
        {
            Instantiate(spells[rIndex], transform.position, Quaternion.identity);
        }

        else if (rList == potionBlueprints)
        {
            Instantiate(potions[rIndex], transform.position, Quaternion.identity);
        }
    }

    void BlueprintTimer(int bPIndex, GameObject[] listBlueprints)
    {
        if (timer > 0.4f)
        {
            //là il faut immobiliser le joueur, et lui permettre de diriger le blueprint avec le joystick gauche

            theBluePrint = Instantiate(listBlueprints[bPIndex], transform.position, Quaternion.identity);
        }

        else
        {
            timer += Time.deltaTime;
        }
    }
}
