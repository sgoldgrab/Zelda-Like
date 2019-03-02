using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject[] spells;
    public GameObject[] potions;

    private float timer = 0f;

    private bool[] keyPressed;

    private string[] spellKey = new string[3];
    private string[] potionKey = new string[3];

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

        spellKey[0] = "Spell1";
        spellKey[1] = "Spell2";
        spellKey[2] = "Spell3";

        potionKey[0] = "Potion1";
        potionKey[1] = "Potion2";
        potionKey[2] = "Potion3";
    }

    void Update()
    {
        WhatStance();
    }

    void WhatStance()
    {
        if (stanceOne)
        {
            Instantiate(potionKey[0], 0, potionBlueprints);
            Instantiate(potionKey[1], 1, potionBlueprints);
            Instantiate(potionKey[2], 2, potionBlueprints);
        }

        else if (!stanceOne)
        {
            Debug.Log(spellKey[0]);
            Instantiate(spellKey[0], 0, spellBlueprints);
            Instantiate(spellKey[1], 1, spellBlueprints);
            Instantiate(spellKey[2], 2, spellBlueprints);
        }
    }

    void Instantiate(string key, int index, GameObject[] list)
    {
        if (Input.GetKeyDown(key) && !isReloading)
        {
            keyPressed[index] = true;

            //Reminder : intégrer bool pour bloquer le mouvement et le switch de stance
        }

        if (keyPressed[index])
        {
            BlueprintTimer(index, list);
        }

        if (Input.GetKeyUp(key) && !isReloading)
        {
            Release(index, list);
        }
    }

    void Release(int rIndex, GameObject[] rList)
    {
        keyPressed[rIndex] = false;
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
