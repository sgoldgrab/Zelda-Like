﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> healthSegs = new List<GameObject>();
    [SerializeField] private string segName;

    [SerializeField] private EntityState state;

    private bool isDead = false;

    private void Start()
    {
        if (gameObject.tag == "Enemy") { state = GetComponentInParent<EntityState>(); }

        //healthSegs = new GameObject[state.health]; // creates the list of size health

        for (int n = 0; n < state.health; n++)
        {
            healthSegs.Add(GameObject.Find(segName + " " + (n + 1).ToString())); // fills the objects of the list with the health segs
        }
    }

    public void UITakeDamage(int currentHealth, int damageIndex)
    {
        int bonusDmg = 0;

        for (int x = 0; x < damageIndex; x++)
        {
            Debug.Log(healthSegs.Count);
            if (healthSegs == null) { Debug.Log("nique ton oncle unity"); }
            else { Debug.Log((currentHealth - 1) - bonusDmg); }
            healthSegs[(currentHealth - 1) - bonusDmg].SetActive(false);
            bonusDmg++;
        }

        bonusDmg = 0;
    }

    public void UITakeHealth(int currentHealth, int healIndex)
    {
        int bonusHeal = 0;

        for (int x = 0; x < healIndex; x++)
        {
            healthSegs[currentHealth + bonusHeal].SetActive(true);
            bonusHeal++;
        }

        bonusHeal = 0;
    }

    public void UIOnDeath() // useless
    {
        isDead = true;
    }
}