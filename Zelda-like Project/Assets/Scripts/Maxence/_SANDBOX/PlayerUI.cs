using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private GameObject[] playerHealthSeg;

    [SerializeField] private PlayerState playerState;

    private bool isDead = false;

    private void Start()
    {
        playerHealthSeg = new GameObject[playerState.maxHealth];

        //playerHealthSeg[0] = GameObject.Find("HealthBarEdge");

        for (int n = 0; n < 5; n++)
        {
            playerHealthSeg[n] = GameObject.Find("healthSegment " + (n + 1).ToString());
        }
    }

    public void UITakeDamage(int currentHealth, int damageIndex)
    {
        int bonusDmg = 0;

        for (int x = 0; x < damageIndex; x++)
        {
            playerHealthSeg[(currentHealth - 1) - bonusDmg].SetActive(false);
            bonusDmg++;
        }

        bonusDmg = 0;
    }

    public void UITakeHealth(int currentHealth, int healIndex)
    {
        int bonusHeal = 0;

        for (int x = 0; x < healIndex; x++)
        {
            playerHealthSeg[(currentHealth - 1) + bonusHeal].SetActive(true);
            bonusHeal++;
        }

        bonusHeal = 0;
    }

    public void UIOnDeath()
    {
        isDead = true;
    }
}
