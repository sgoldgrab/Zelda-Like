using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{

    private GameObject playerHealthOne;
    private GameObject playerHealthTwo;
    private GameObject playerHealthThree;
    private GameObject playerHealthFour;
    private GameObject playerHealthFive;

    private bool damageOne = false;
    private bool damageTwo = false;
    private bool damageThree = false;
    private bool damageFour = false;

    public bool isDead = false;

    private void Start()
    {

        playerHealthOne = GameObject.Find("SEG1");
        playerHealthTwo = GameObject.Find("SEG2");
        playerHealthThree = GameObject.Find("SEG3");
        playerHealthFour = GameObject.Find("SEG4");
        playerHealthFive = GameObject.Find("SEG5");

    }

    public void TakeDamage()
    {

        if (damageFour)
        {

            playerHealthFour.SetActive(false);

            PlayerDead();
            damageOne = false;
            damageTwo = false;
            damageThree = false;
            damageFour = false;

        }

        else if (damageThree)
        {

            playerHealthThree.SetActive(false);

            damageFour = true;

        }

        else if (damageTwo)
        {

            playerHealthOne.SetActive(false);

            damageThree = true;

        }

        else if (damageOne)
        {

            playerHealthTwo.SetActive(false);

            damageTwo = true;

        }

        else
        {

            playerHealthFive.SetActive(false);

            damageOne = true;

        }

    }

    public void PlayerDead()
    {

        isDead = true;

    }

}
