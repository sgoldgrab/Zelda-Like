using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityUI : MonoBehaviour
{
    private GameObject[] healthSegs;
    [SerializeField] private string segName;

    [SerializeField] private EntityState state;

    private bool isDead = false;

    private void Start()
    {
        if (gameObject.tag == "Enemy") { state = GetComponentInParent<EntityState>(); }

        healthSegs = new GameObject[state.health]; // creates the list of size health

        for (int n = 0; n < state.health; n++)
        {
            healthSegs[n] = GameObject.Find(segName + " " + (n + 1).ToString()); // fills the objects of the list with the health segs
        }
    }

    public void UITakeDamage(int currentHealth, int damageIndex)
    {
        int bonusDmg = 0;

        for (int x = 0; x < damageIndex; x++)
        {
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
