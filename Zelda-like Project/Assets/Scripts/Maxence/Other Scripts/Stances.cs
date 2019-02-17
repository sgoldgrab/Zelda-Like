using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stances : MonoBehaviour
{

    public bool stanceOne = true;

    private SpriteRenderer sprite;

    private void Start()
    {

        sprite = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {

        Inputs();

    }

    private void Inputs()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            SwitchStances();

        }

    }

    private void SwitchStances()
    {

        if(stanceOne)
        {

            stanceOne = false;
            sprite.color = new Color(0, 0, 255);

        }

        else if(!stanceOne)
        {

            stanceOne = true;
            sprite.color = new Color(255, 0, 0);

        }

    }

}
