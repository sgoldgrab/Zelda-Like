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
        playerHealthSeg = new GameObject[playerState.playerMaxHealth + 1];

        //playerHealthSeg[0] = GameObject.Find("HealthBarEdge");

        for (int n = 1; n <= 5; n++)
        {
            playerHealthSeg[n] = GameObject.Find("healthSegment " + n.ToString());
        }
    }

    public void UITakeDamage(int currentHealth, int damageIndex)
    {
        int bonusDmg = 0;

        //playerHealthSeg[playerState.playerHealth + 1].SetActive(false);
        for (int x = 0; x < damageIndex; x++)
        {
            playerHealthSeg[currentHealth - bonusDmg].SetActive(false);
            bonusDmg++;
        }

        bonusDmg = 0;
    }

    public void UITakeHealth(int currentHealth, int healIndex)
    {
        int bonusHeal = 0;

        for (int x = 0; x < healIndex; x++)
        {
            playerHealthSeg[currentHealth + bonusHeal].SetActive(true);
            bonusHeal++;
        }

        bonusHeal = 0;
    }

    public void UIOnDeath()
    {
        isDead = true;
    }
}
