using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{

    private Stances scriptStances;

    private void Start()
    {

        scriptStances = GetComponent<Stances>();

    }

    private void Update()
    {

        Inputs();

    }

    private void Inputs()
    {

        if(!scriptStances.stanceOne)
        {

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {

                SpellOne();

            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {

                SpellTwo();

            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {

                SpellThree();

            }

        }

        else if(scriptStances.stanceOne)
        {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                PotionOne();

            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {

                PotionTwo();

            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {

                PotionThree();

            }

        }

    }

    private void SpellOne()
    {

        

    }

    private void SpellTwo()
    {



    }

    private void SpellThree()
    {



    }

    private void PotionOne()
    {



    }

    private void PotionTwo()
    {



    }

    private void PotionThree()
    {



    }

}
