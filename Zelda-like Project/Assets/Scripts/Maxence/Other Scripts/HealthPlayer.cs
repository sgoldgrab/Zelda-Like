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

    [HideInInspector] public int damageTaken = 0;

    [HideInInspector] public bool isDead = false;

    private void Start()
    {

        playerHealthOne = GameObject.Find("healthSegment 1");
        playerHealthTwo = GameObject.Find("healthSegment 2");
        playerHealthThree = GameObject.Find("healthSegment 3");
        playerHealthFour = GameObject.Find("healthSegment 4");
        playerHealthFive = GameObject.Find("healthSegment 5");

    }

    public void TakeDamage()
    {

        if (damageTaken == 4)
        {

            playerHealthFour.SetActive(false);

            PlayerDead();
            damageTaken = 0;

        }

        else if (damageTaken == 3)
        {

            playerHealthThree.SetActive(false);

            damageTaken += 1;

        }

        else if (damageTaken == 2)
        {

            playerHealthOne.SetActive(false);

            damageTaken += 1;

        }

        else if (damageTaken == 1)
        {

            playerHealthTwo.SetActive(false);

            damageTaken += 1;

        }

        else
        {

            playerHealthFive.SetActive(false);

            damageTaken += 1;

        }

    }

    public void PlayerDead()
    {

        isDead = true;

    }

}
